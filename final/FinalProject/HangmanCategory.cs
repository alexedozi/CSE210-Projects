public class HangmanCategory
    {
        private List<string> categories;
        public bool CategoryEnabled { get; private set; }
        private int selectedCategoryIndex;

        public HangmanCategory()
        {
            categories = new List<string>
            {
                "Animals", "Music", "Beach", "Party", "City", "School", "Grocery", "Sports", "Leisure", "Wild West"
            };
            CategoryEnabled = false;
        }

        public List<string> GetCategories()
        {
            return categories;
        }

        public void SelectCategory(int index)
        {
            selectedCategoryIndex = index;
            CategoryEnabled = true;
        }

        public string GetSelectedCategory()
        {
            return categories[selectedCategoryIndex];
        }
    }