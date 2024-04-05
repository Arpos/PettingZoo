/*- There will be three visiting schools
    - School A has six visiting groups (the default number)
    - School B has three visiting groups
    - School C has two visiting groups

- For each visiting school, perform the following tasks
    - Randomize the animals
    - Assign the animals to the groups
    - Print the school name
    - Print the animal groups*/
using PettingZoo;

internal class Program
{
    public static string[] PettingZoo { get; } = [
    "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
    "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
    "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
];
    static List<string> animalList = [];
    static List<School> schools = [];

    private static void Main(string[] args)
    {
        InitializeSchools();

        foreach (School school in schools)
        {
            List<List<string>> Groups = AnimalsinGroups(school.Groups);
            Console.WriteLine(@"School {0} will be there in {1} groups", school.Name, school.Groups);
            for (int i = 0; i < Groups.Count; i++)
            {
                var result = string.Join(", ", Groups[i].ToArray());
                Console.WriteLine(@"Group {0}, will be seeing those animals: {1}.", i, result);
                
            }
            Console.WriteLine();
        }
    }

    public static void InitializeSchools()
    {
        schools.Add(new School("School A", 6));
        schools.Add(new School("School B", 3));
        schools.Add(new School("School C", 2));
    }
    public static void CreateAnimalList()
    {
        Random random = new Random();

        string[] Randomizedanimals = PettingZoo;
        for (int i = 0; i < PettingZoo.Length; i++)
        {
            int r = random.Next(Randomizedanimals.Length);
            string temp = Randomizedanimals[i];
            Randomizedanimals[i] = Randomizedanimals[r];
            Randomizedanimals[r] = temp;
        }

        List<string> newList = new List<string>();
        foreach (string animal in Randomizedanimals)
            newList.Add(animal);

        animalList = newList;
    }
    public static List<List<string>> AnimalsinGroups(int groups)
    {
        List<List<string>> done = [];
        CreateAnimalList();
        int iterations = animalList.Count / groups;

        for (int group = 0; group < groups; group++)
        {
            List<string> GroupedAnimals = [];
            done.Add(GroupedAnimals);
            int i = 0;
            for (int animaln = animalList.Count - 1; animaln >= 0; animaln--)
            {
                if (i < iterations)
                {
                    string animal = animalList[animaln];
                    GroupedAnimals.Add(animal);
                    animalList.Remove(animal);
                    i++;
                }
            }
        }
        return done;
    }
}