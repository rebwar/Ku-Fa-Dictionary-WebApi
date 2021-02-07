using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ku_Fa_Dictionary.Data;
using Ku_Fa_Dictionary.Models;
using Microsoft.EntityFrameworkCore;

namespace Ku_Fa_Dictionary.Services
{
    public class DictionaryService : IDictionaryService
    {
        private readonly DictionaryDbContext _context;

        public DictionaryService(DictionaryDbContext context)
        {
            _context = context;
        }
        public async Task AddWords(Dictionary dictionary)
        {
            await _context.Dictionaries.AddAsync(dictionary);
            _context.SaveChanges();
        }

        public async Task<bool> DeleteWord(int id)
        {
            var result = await GetWordById(id);
            if (result != null)
            {
                _context.Dictionaries.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<Dictionary> GetWordById(int id) => await _context.Dictionaries.FirstOrDefaultAsync(q => q.Id == id);


        public async Task EditWord(int id, Dictionary dictionary)
        {
            var result = await GetWordById(id);
            if (result != null)
            {
                result.Farsi = dictionary.Farsi;
                result.Kurdish = dictionary.Kurdish;
                _context.Dictionaries.Update(result);
                _context.SaveChanges();
            }

        }

        public async Task<IEnumerable<Dictionary>> GetAllWords() => await _context.Dictionaries.ToListAsync();

        public async Task<IEnumerable<Dictionary>> GetWord(string word)=>await _context.Dictionaries.Where(c => c.Kurdish.Contains(word) || c.Farsi.Contains(word)).ToListAsync();


    }
}