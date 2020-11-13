using RopeDetection.Entities.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace RopeDetection.Entities.Models
{
    public class User: EntityBase
    {
        public User()
        {
            AnalyzedObjects = new List<AnalyzedObject>();
            FileDatas = new List<FileData>();
            Models = new List<Model>();
        }

        public string UserFIO { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] HashedPassword { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Признак допуска в систему
        /// </summary>
        public bool IsAllowed { get; set; }

        public List<AnalyzedObject> AnalyzedObjects { get; private set; }
        public List<FileData> FileDatas { get; private set; }
        public List<Model> Models { get; private set; }


        public static User Create(string userFIO, string description = null, string UserName = null, string Password = null, string Email = null, bool IsAllowed = false)
        {
            var user = new User
            {
                UserName = string.IsNullOrEmpty(UserName) ? (RussianTransliteration.RussianTransliterator.GetTransliteration(userFIO) ?? "").Replace(" ", "") : UserName,
                UserFIO = userFIO,
                Description = description,
                Password = string.IsNullOrEmpty(Password) ? Guid.NewGuid().ToString() : Password,
                HashedPassword = new byte[0],
                Email = Email,
                IsAllowed = IsAllowed
            };
            return user;
        }
    }
}
