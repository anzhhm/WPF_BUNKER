using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BUNKER.GameGeneration
{
    class CharacterViewModel
    {
        public string Player { get; set; }
        public string SexAndAge { get; set; }
        public string Profession { get; set; }
        public string HealthAndHeight { get; set; }
        public string Hobby { get; set; }
        public string Inventory { get; set; }
        public string AdditionalInfo1 { get; set; }
        public string AdditionalInfo2 { get; set; }

        public CharacterViewModel(string character)
        {
            string[] lines = character.Split('\n');

            Player = lines[0]; // Гравець {characterCount}

            string[] sexAndAgeParts = lines[1].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            SexAndAge = sexAndAgeParts[1].Trim();

            string[] professionParts = lines[2].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            Profession = professionParts[1].Trim();

            string[] healthAndHeightParts = lines[3].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            HealthAndHeight = healthAndHeightParts[1].Trim();

            string[] hobbyParts = lines[4].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            Hobby = hobbyParts[1].Trim();

            string[] inventoryParts = lines[5].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            Inventory = inventoryParts[1].Trim();

            string[] additionalInfo1Parts = lines[6].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            AdditionalInfo1 = additionalInfo1Parts[1].Trim();

            string[] additionalInfo2Parts = lines[7].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            AdditionalInfo2 = additionalInfo2Parts[1].Trim();
        }
    }
}
