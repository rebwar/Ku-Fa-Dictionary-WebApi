using System.ComponentModel.Design;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ku_Fa_Dictionary.Services;
using Ku_Fa_Dictionary.Models;

namespace Ku_Fa_Dictionary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DictionaryController : ControllerBase
    {
        private readonly Services.IDictionaryService _dictionary;

        public DictionaryController(Services.IDictionaryService dictionary)
        {
            _dictionary = dictionary;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWords()
        {
            var result = await _dictionary.GetAllWords();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{word}")]
        public async Task<IActionResult> GetWord(string word)
        {
            var result = await _dictionary.GetWord(word);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditWord(int id, Dictionary dictionary)
        {
            if (id != dictionary.Id)
            {

                return NotFound();

            }
            else
            {
                await _dictionary.EditWord(id, dictionary);
                return Ok();
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> deleteWord(int id)
        {

            var deleted = await _dictionary.DeleteWord(id);
            if (deleted)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddWord(Dictionary dictionary)
        {
            if (ModelState.IsValid)
            {
                await _dictionary.AddWords(dictionary);
                return CreatedAtAction(nameof(GetWordById), new { id = dictionary.Id }, dictionary);
            }
            return BadRequest();
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetWordById(int id)
        {
            var result = await _dictionary.GetWordById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }


    }
}