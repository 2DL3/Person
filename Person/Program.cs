using PersonAssignment;
using PersonLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAssignment
{
    /// <summary>
    /// Internal means not visible outside assembly
    /// </summary>
    internal class Person 
    {
        //Fields storing the information about person
        //private means only Class Person can use them
        //private field is used to encapsulate the data... they can only be accessed and modified from within the class
        private int personId;
        private string personFirstName;
        private string personLastName;
        private string personFavoriteColor;
        private int personAge;
        private bool personIsWorking;

        /// <summary>
        ///  Constructors to initialize values
        ///  this. used to assign properties to respective properties like PersonID in lines45
        /// </summary>

        public Person (int personId, string personFirstName, string personLastName, string personFavoriteColor, int personAge, bool personIsWorking)
        {
            this.PersonId = personId;
            this.PersonFirstName = personFirstName;
            this.PersonLastName = personLastName;
            this.PersonAge = personAge;
            this.PersonFavoriteColor = personFavoriteColor;
            this.PersonIsWorking = personIsWorking;
        }
        //Properties 
        //defining the properties
        //getter allows to return value of the respective fields
        //setter allows to set the value of the respective field
        //Value   represents the value being assigned to the property.
        public int PersonId
        {
            get { return personId; }
            set { personId = value; }
        }
        public string PersonFirstName
        {
            get { return personFirstName; }
            set { personFirstName = value; }
        }
        public string PersonLastName
        {
            get { return personLastName; }
            set { personLastName = value; }
        }
        public string PersonFavoriteColor
        {
            get { return personFavoriteColor; }
            set { personFavoriteColor = value; }
        }
        public int PersonAge
        {
            get { return personAge; }

            set ///validating age value is correct
            {
                if (value >= 0 && value <= 122)
                {
                    personAge = value;
                }
            }
        }
        public bool PersonIsWorking
        {
            get { return personIsWorking; }
            set { personIsWorking = value; }
        }

        // List of Methods
        // method to display info with its respective fields
        // return value is mandatory
        public string DisplayPersonInfo()
        {
            return $"ID: {PersonId}\nFirst name: {PersonFirstName}\nLast name: {PersonLastName}\nAge: {PersonAge}\nFavorite Color: {PersonFavoriteColor}\nIs Working: {PersonIsWorking}";
        }
        /// <summary>
        /// Void doesn't return anything just doing some operations inside
        /// change color to white
        /// </summary>
        public void ChangeFavoriteColor()
        {
            personFavoriteColor = "White";
        }

        /// Gets current person age in 10 years 
        public int GetAgeInTenYears()
        {
            int ageAfterTenYears = personAge + 10;

            return ageAfterTenYears;
        }
        public override string ToString() ///override signifies that program will have its own implementaiton of Tostring representing person information if without override To.string will produce the namespaceclass
        {
            return $"PersonID: {personId}\nFirst name {personFirstName}\nLast name {personLastName}\nFavoriteColour: {PersonFavoriteColor}\nAge:{PersonAge}\nIsWorking: {PersonIsWorking}";
        }

    }
}

namespace PersonLab
{
    /// <summary>
    /// Internal means not visible outside assembly
    /// </summary>
    internal class Relation ///internal means only accessible at the same assembly
    {
        //Fields
        private string person1Relation;
        private string person2Relation;

        private Person person1;
        private Person person2;

        //properties
        //defining the properties
        public string Person1Relation
        {
            get { return person1Relation; }
            set { person1Relation = value; }
        }
        public string Person2Relation
        {
            get { return person2Relation; }
            set { person2Relation = value; }
        }

        public Person Person1
        {
            get { return person1; }
            set { person1 = value; }
        }
        public Person Person2
        {
            get { return person2; }
            set { person2 = value; }
        }

        //setting up constructors and accessing it to the properties
        public Relation(string person1Relation, Person person1, string person2Relation, Person person2)
        {
            this.Person1Relation = person1Relation;
            this.Person1 = person1;
            this.Person2Relation = person2Relation;
            this.Person2 = person2;
        }

        public override string ToString() //states that person1 is either a sisterhood or brotherhood of person 2 utilizing the first names.
        {
            return $"{Person1.PersonFirstName} is a {Person1Relation}\n{Person2.PersonFirstName} is a {Person2Relation}\n";
        }
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        // Create Person objects
        Person person1 = new Person(1, "Ian", "Brooks", "Red", 30, true);
        Person person2 = new Person(2, "Gina", "James", "Green", 18, false);
        Person person3 = new Person(3, "Mike", "Briscoe", "Blue", 45, true);
        Person person4 = new Person(4, "Mary", "Beals", "Yellow", 28, true);

        // Display Gina's information
        string ginaFavoriteColor = $"{person2.PersonId}: {person2.PersonFirstName} {person2.PersonLastName}'s favorite color is {person2.PersonFavoriteColor}";
        Console.WriteLine(ginaFavoriteColor);

        // Display Mike's information
        string mikesInfo = person3.ToString();
        Console.WriteLine(mikesInfo);

        // Change Ian's favorite color to white 
        // accesssed the method then called out the variable holding color white
        person1.ChangeFavoriteColor();
        string ianFavoriteColorToWhite = $"{person1.PersonFirstName} {person1.PersonLastName}'s favorite colour is {person1.PersonFavoriteColor}";
        Console.WriteLine(ianFavoriteColorToWhite);

        // Display Mary's age in 10 years
        int marysAgeTenYears = person4.GetAgeInTenYears();
        string marysAgeInfo = $"{person4.PersonFirstName} {person4.PersonLastName}'s age in 10 years is : {marysAgeTenYears}";
        Console.WriteLine(marysAgeInfo);

        // Create Relation instances (linking Person instances together)
        // display relation
        Relation ginaMaryRelation = new Relation("Sisterhood", person2, "Sisterhood", person4);
        string relation1 = $"Relationship between {ginaMaryRelation.Person1.PersonFirstName} and {ginaMaryRelation.Person2.PersonFirstName} is: {ginaMaryRelation.Person1Relation}";
        Console.WriteLine(relation1.ToString());
        Relation ianMikeRelation = new Relation("Brotherhood", person1, "Brotherhood", person3);
        string relation2 = $"Relationship between {ianMikeRelation.Person1.PersonFirstName} and {ianMikeRelation.Person2.PersonFirstName} is: {ianMikeRelation.Person1Relation}";
        Console.WriteLine(relation2.ToString());


        // Create and populate list of people
        List<Person> people = new List<Person>();

        people.Add(person1);
        people.Add(person2);
        people.Add(person3);
        people.Add(person4);

        // Determine average age
        int sum = 0;

        // Get sum of everyone's age
        foreach (Person person in people)
        {
            sum += person.PersonAge;
        }

        // Divide sum by number of people.
        // One operand for / operator must be double for result to be double.
        double average = sum / (double)people.Count;

        // Display average age
        Console.WriteLine("Average age: " + average);
        // displaying the youngest and oldest
        Person personYoungest = null;
        Person personOldest = null;

        foreach (Person person in people) /// || is or
        {
            if (personYoungest == null || person.PersonAge < personYoungest.PersonAge) // this checks if (youngestPerson is not set or current person is younger)

            {
                personYoungest = person;
            }

            if (personOldest == null || person.PersonAge > personOldest.PersonAge)
            {
                personOldest = person;
            }
        }

        // Display the youngest and oldest person
        Console.WriteLine($"The youngest person is: {personYoungest.PersonFirstName}");
        Console.WriteLine($"The oldest person is: {personOldest.PersonFirstName}");
        
        //displaying people with starting letter as M
        
        foreach (Person person in people)
        {
            if (person.PersonFirstName[0] == 'M') //checks if the first element of the first name is letter M
            {
                Console.WriteLine($"PersonId: {person.PersonId}\nFirstName: {person.PersonFirstName}\nLastName: {person.PersonLastName}\nFavoriteColour: {person.PersonFavoriteColor}\nAge: {person.PersonAge}\nIsWorking: {person.PersonIsWorking}");
            }
        }
        // search for people whos favorite color is blueand display their information
        foreach (Person person in people)
        {
            if  (person.PersonFavoriteColor == "Blue")
            {
                Console.WriteLine($"PersonId: {person.PersonId}\nFirstName: {person.PersonFirstName}\nLastName: {person.PersonLastName}\nFavoriteColour: {person.PersonFavoriteColor}\nAge: {person.PersonAge}\nIsWorking: {person.PersonIsWorking}");
            }
        }
    }
}