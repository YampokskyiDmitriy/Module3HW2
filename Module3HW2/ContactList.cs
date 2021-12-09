using System.Collections.Generic;
using Module3HW2.Models;

namespace Module3HW2.Collection
{
    public class ContactList
    {
        private readonly Dictionary<string, string> _alphabet;
        private Dictionary<string, List<Contact>> _section;
        private string _culture;
        public ContactList()
        {
            _section = new Dictionary<string, List<Contact>>();
            _alphabet = new Dictionary<string, string>();
            _culture = "en-EN";
            _alphabet.Add("ru-RU", "цукенгшщзхъфывапролджэячсмитьбюё");
            _alphabet.Add("en-EN", "qwertyuiopasdfghjklzxcvbnm");
        }

        public void SetCulture(string culture)
        {
            if (_culture.Equals(culture) && !_alphabet.ContainsKey(culture))
            {
                return;
            }

            _culture = culture;
            var oldSection = _section;
            var newSection = new Dictionary<string, List<Contact>>();
            _section = newSection;
            foreach (var collection in oldSection)
            {
                foreach (var item in collection.Value)
                {
                    Add(item);
                }
            }
        }

        public List<Contact> GetSection(string sectionKey)
        {
            if (_section.ContainsKey(sectionKey))
            {
                return _section[sectionKey];
            }

            return null;
        }

        public void Add(Contact contact)
        {
            var firstChar = contact.FullName.Trim().ToLower()[0];
            if (char.IsNumber(firstChar))
            {
                AddToSection("0-9", contact);
                return;
            }

            if (_alphabet[_culture].Contains(firstChar))
            {
                AddToSection(firstChar.ToString(), contact);
                return;
            }

            AddToSection("#", contact);
        }

        public IEnumerator<Contact> GetEnumerator()
        {
            foreach (var collection in _section)
            {
                foreach (var item in collection.Value)
                {
                    yield return item;
                }
            }
        }

        private void AddToSection(string sectionKey, Contact contact)
        {
            if (_section.ContainsKey(sectionKey))
            {
                _section[sectionKey].Add(contact);
                return;
            }

            var list = new List<Contact>();
            list.Add(contact);
            _section.Add(sectionKey, list);
        }
    }
}
