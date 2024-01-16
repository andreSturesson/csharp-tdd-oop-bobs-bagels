
namespace exercise.main {

    public class Stock {
        private Dictionary<string, Item> Bagels;
        private Dictionary<string, Item> Coffee;
        private Dictionary<string, Item> Filling;

        public Stock() {
            Bagels = new Dictionary<string, Item>();
            Coffee = new Dictionary<string, Item>();
            Filling = new Dictionary<string, Item>();
        }
    }


}