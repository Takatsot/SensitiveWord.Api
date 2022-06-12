using Microsoft.AspNetCore.Mvc;
using SensitiveWord.Api.Helper;
using SensitiveWord.Api.Models;
using SensitiveWord.Api.SensitiveWord.SC;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SensitiveWord.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensitiveWordsController : ControllerBase
    {
        private readonly ISensitiveWords _service;
        public SensitiveWordsController(ISensitiveWords sensitiveWords)
        {
            _service = sensitiveWords;
        }


        /// You can use this to import the file to the database
        /// GET: SensitiveWordsController/ImportTextData
        [HttpGet("import-file")]   
        public async Task<object> ImportTextData()
        {
            try
            {
                var _words = ImportFile.ReadFile();

                foreach (var _word in _words)
                {
                    var _newWord =  RemoveUnwantedCharacters(_word);

                    if (!string.IsNullOrEmpty(_newWord))
                        AddWord(_newWord).GetAwaiter().GetResult();
                }
                return new HttpResponseMessage { StatusCode = HttpStatusCode.OK, ReasonPhrase = "Data uploaded successfully" };
            }
            catch (Exception ex)
            { 
                return new HttpResponseMessage { StatusCode = HttpStatusCode.OK, ReasonPhrase = ex.Message.ToString() };
                throw;       
            }
        }


        // GET: api/GetWords
        [HttpGet("get-words")]
        public async Task<List<Word>> GetWords()
        {
            return await _service.GetWords();
        }

        // GET: api/Getword/word
        [HttpGet("get-word")]
        public async Task<object> Getword(string word)
        {
            var aword  = await _service.GetBlackListedWordsAsync(word);
            if (aword == null)
            {
                return NotFound();
            }
            return Ok(aword);
        }

        // POST: api/Getword/word
        [HttpPost("add-word")]
        public async Task<object> AddWord(string word)
        {
            var results = await _service.AddAWord(word);
            if (results > 0)
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    ReasonPhrase = "Word added Succesfully"
                };

            return new HttpResponseMessage {StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = "Word Not added Succesfully"};
        }

        // PUT: api/Getword/word
        [HttpPut("update-word")]
        public async Task<object> UpdateWord(string word,int wordId)
        {
            var results = await _service.UpdateAWord(word, wordId);

            if (results > 0)
                return new HttpResponseMessage { StatusCode = HttpStatusCode.OK, ReasonPhrase = "Word Updated Succesfully" };

            return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = "Please check your input" };
        }

        // POST: api/Getword/id
        [HttpDelete("remove-word")]
        public async Task<object> RemoveWord(int id)
        {
            var results = await _service.RemoveAWord(id);
            if (results)
                return new HttpResponseMessage { StatusCode = HttpStatusCode.OK, ReasonPhrase = "Word Removed Succesfully" };

            return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = results.ToString() };
        }

        // Remove all other funny charecters found on the file other than space,dot, underscore and *
        private string RemoveUnwantedCharacters(string str)
        {
            var sb = new StringBuilder();

            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == '*' ||c == ' ')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
