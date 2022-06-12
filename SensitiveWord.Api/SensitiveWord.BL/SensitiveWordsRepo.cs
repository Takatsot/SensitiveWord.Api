using Microsoft.EntityFrameworkCore;
using SensitiveWord.Api.Models;
using SensitiveWord.Api.Repository.Data;
using SensitiveWord.Api.SensitiveWord.BL;
using SensitiveWord.Api.SensitiveWord.SC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensitiveWord.Api.SensitiveWord.SL
{
    public class SensitiveWordsRepo : ISensitiveWordsRepo
    {
        #region Declarations
        private readonly SensitiveWordsDBContext _dbContext;
        private BloopSensetiveWords _bloob;

        #endregion

        #region Constructor
        public SensitiveWordsRepo(SensitiveWordsDBContext context)
        {
            _dbContext = context;
        }
        #endregion

        
        #region Modify Methods

        /// <summary>
        /// Adds a new word
        /// </summary>
        /// <param name="word">Word</param>
        public async Task<int> AddAWord(string word)
        {
            try
            {
                if (string.IsNullOrEmpty(word))
                {
                    return 400;
                }

                _dbContext.Words.Add(new Word { Aword = word });
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);

                return 0;
            }
        }


        /// <summary>
        /// Update a word 
        /// </summary>
        /// <param name="word">Words </param>
        public async Task<int> UpdateAWord(string word, int wordId)
        {
            try
            {
                if (string.IsNullOrEmpty(word)&& wordId > 0)
                {
                    return 400;
                }

                var aword = await _dbContext.Words.FindAsync(wordId);

                if(aword.WordId != 0 && !string.IsNullOrEmpty(aword.Aword))
                {
                    aword.Aword = word;
                    _dbContext.Update(aword);
                 return _dbContext.SaveChanges() ;
                }

                return 400;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 400;
            }
        }


        /// <summary>
        /// Remove a word
        /// </summary>
        /// <param name="id">Word id</param>
        public async Task<bool> RemoveAWord(int id)
        {
            try
            {
                if (id == 0)
                {
                    return false;
                }

                var aword = await _dbContext.Words.FindAsync(id);
                _dbContext.Remove(aword);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        #endregion

        #region Read Methods

        /// <summary>
        /// Get a list of all words
        /// </summary>
        /// <returns>List of all words</returns>
        public async Task<List<Word>> GetWords()
        {
            try
            {
                return await _dbContext.Words.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Get a list of all blacklisted words
        /// </summary>
        /// <returns>List of all bloobed words</returns>
        public async Task <string> GetBlackListedWordsAsync(string word)
        {  
            try
            {
                _bloob = new BloopSensetiveWords();
                var data = await _dbContext.Words.Select(w => w.Aword).ToListAsync();

                if (data != null)
                   return _bloob.BloobWords(data, word);

                return "Word Not Found";
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Get a word
        /// </summary>
        /// <returns>a word object using a word</returns>
        public async Task<string> GetAWord(string word)
        {
            try
            {
                if (string.IsNullOrEmpty(word))
                {
                    return "Please provide word";
                }

                var aword = await _dbContext.Words.FindAsync(word);

                if (aword != null && !string.IsNullOrEmpty(aword.Aword))
                    return aword.Aword;

                return "Word Not Found";
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return ex.Message.ToString();
            }
        }

        #endregion
    }
}
