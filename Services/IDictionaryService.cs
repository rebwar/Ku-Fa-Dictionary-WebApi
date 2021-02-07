using System.Collections.Generic;
using System.Threading.Tasks;
using Ku_Fa_Dictionary.Models;

namespace Ku_Fa_Dictionary.Services
{
    public interface IDictionaryService
    {
         Task AddWords(Dictionary dictionary);
         Task<IEnumerable<Dictionary>> GetAllWords();
         Task<IEnumerable<Dictionary>> GetWord(string word);

         Task<bool> DeleteWord(int id);

         Task EditWord(int id,Dictionary dictionary);
         Task<Dictionary> GetWordById(int id);
    }
}