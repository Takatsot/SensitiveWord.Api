using SensitiveWord.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensitiveWord.Api.SensitiveWord.SC
{
    public interface ISensitiveWords
    {
        #region Modify Methods

        /// <summary>
        /// Adds a new word
        /// </summary>
        /// <param name="word">Word</param>
        Task<int> AddAWord(string word);


        /// <summary>
        /// Update a word 
        /// </summary>
        /// <param name="word">Words </param>
        Task<int> UpdateAWord(string word,int wordId);


        /// <summary>
        /// Remove a word
        /// </summary>
        /// <param name="id">Word id</param>
        Task<bool> RemoveAWord(int id);

        #endregion

        #region Read Methods

        /// <summary>
        /// Get a list of all words
        /// </summary>
        /// <returns>List of all words</returns>
         Task<List<Word>> GetWords();

        /// <summary>
        /// Get a list of all blacklisted words
        /// </summary>
        /// <returns>List of all bloobed words</returns>
        Task<string> GetBlackListedWordsAsync(string word);

        /// <summary>
        /// Get a word
        /// </summary>
        /// <returns>a word object using a word</returns>
        Task<string> GetAWord(string word);

        #endregion
    }
}
