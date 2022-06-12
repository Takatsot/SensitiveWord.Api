using SensitiveWord.Api.Models;
using SensitiveWord.Api.SensitiveWord.SC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensitiveWord.Api.SensitiveWord.SL
{
    public class SensitiveWordsService : ISensitiveWords
    {
        private readonly ISensitiveWordsRepo _repository;
        public SensitiveWordsService(ISensitiveWordsRepo repository)
        {
            _repository = repository;
        }

        #region Modify Methods

        /// <summary>
        /// Adds a new word
        /// </summary>
        /// <param name="word">Word</param>
        public async Task<int> AddAWord(string word)
        {
            try
            {
                return await _repository.AddAWord(word);
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
        /// <param name="word">Words</param>
        public async Task<int> UpdateAWord(string word, int wordId)
        {
            try
            {
                return await _repository.UpdateAWord(word, wordId);
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
                return  await _repository.RemoveAWord(id);
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
                return await _repository.GetWords();
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
        public async Task<string> GetBlackListedWordsAsync(string word)
        {
            try
            {
                return await _repository.GetBlackListedWordsAsync(word);
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
               return await _repository.GetAWord(word);
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
