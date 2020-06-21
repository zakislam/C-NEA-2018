using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace _2018_NEA
{
    class Program
    {
        static string password;

        static string[,] Bio_questions = { {"1.Name the organelles where protiens are synthesised? A.Ribosome or B.Mitchodria: ","2.What enzyme breaks down carbohydrases? A.Lipids or B.Carbohydrases: ","3.What is meant by the definition of comunicable disease? A.The disease can talk or B.A disease that can be transmitted from person to person: ","4.Define photosynthesis? A.the process where plants sunlight to synthesize nutrients from carbon dioxide and water or B.Where plants take pictures: ","5.What part of your body never stops growing? A.Ears or B.Hands: " },
                {"1.Name the organelles where protiens are synthesised? A.Ribosome or B.Mitchodria or C.Nucleaus: ","2.What enzyme breaks down carbohydrases? A.Lipids or B.Carbohydrases or C.Protease: ","3.What is meant by the definition of comunicable disease? A.The disease can talk or B.A disease that can be transmitted from person to person or C.A disease that can\"t be transmitted from person to person: ","4.Define photosynthesis? A.the process where plants sunlight to synthesize nutrients from carbon dioxide and water or B.Where plants take pictures or C.Where plants use sunlight and oxygen to synthesize nutrients?: ","5.What part of your body never stops growing? A.Ears or B.Hands or C.Feet: " },
                { "1.Name the organelles where protiens are synthesised? A.Ribosome or B.Mitchodria or C.Nucleaus or D.Vacuole: ","2.What enzyme breaks down carbohydrases? A.Lipids or B.Carbohydrases or C.Protease or D.Amylase: ","3.What is meant by the definition of comunicable disease? A.The disease can talk or B.A disease that can be transmitted from person to person or C.A disease that can\"t be transmitted from person to person or D.A communist disease: ","4.Define photosynthesis? A.the process where plants sunlight to synthesize nutrients from carbon dioxide and water or B.Where plants take pictures or C.Where plants use sunlight and oxygen to synthesize nutrients or D.Where plants user CO2 and glucose to produce Oxygen: ","5.What part of your body never stops growing? A.Ears or B.Hands or C.Feet D.Body: "} };

        static string[,] Phy_questions = {{"1.What is largest planet in our solar system? A.Jupiter or B.Saturn: ","2.Which of the following planets does not have rings? A.Mars or B.Saturn: ","3.How long does it take the Earth to complete a full orbit around the Sun? A.2 years or B.1 year: ","4.Whats the biggest star in our solar system? A.The sun or B.The moon: ","5.What is the hottest planet in our solar system? A.Mercury or B.Venus: "},
                 {"1.What is largest planet in our solar system? A.Jupiter or B.Saturn or C.Neptune: ","2.Which of the following planets does not have rings? A.Mars or B.Saturn or C.Juipter: ","3.How long does it take the Earth to complete a full orbit around the Sun? A.2 years or B.1 year or C.10 years: ","4.Whats the biggest star in our solar system? A.The sun or B.The moon or C.The Earth: ","5.What is the hottest planet in our solar system? A.Mercury or B.Venus or C.Mars: "},
                 {"1.What is largest planet in our solar system? A.Jupiter or B.Saturn or C.Neptune or D.Uranus: ","2.Which of the following planets does not have rings? A.Mars or B.Saturn or C.Jupiter or D.Uranus: ","3.How long does it take the Earth to complete a full orbit around the Sun? A.2 years or B.1 year or C.10 years or D.100 years: ","4.Whats the biggest star in our solar system? A.The sun or B.The moon or C.The Earth or D.None of these: ","5.What is the hottest planet in our solar system? A.Mercury or B.Venus or C.Mars or D.Pluto: "}};

        static string[,] Cs_questions = {{ "1.Hexadecimal means? A.Base 16 or B.Base 8: ","2.How many bits are in a byte? A.6 or B.8: ","3.How many MB in a Gigga byte A.1024MB or B.2028MB: ","4.Define open source software A.It\"s an open bottle of ketchup or B.It\"s a free program: ","5.Which of these is an example of secondry? A.SSD or B.Cache: "},
                { "1.Hexadecimal means? A.Base 16 or B.Base 8 or C.base 10: ","2.How many bits are in a byte? A.6 or B.8 or C.16: ","3.How many MB in a Gigga byte A.1024MB or B.2028MB or C.1024kb: ","4.Define open source software A.It\"s an open bottle of ketchup or B.It\"s a free program OR C.It\"s a paid subscription: ","5.Which of these is an example of secondry? A.SSD or B.Cache or C.RAM: "},
                { "1.Hexadecimal means? A.Base 16 or B.Base 8 or C.base 10 or D.Base 2: ","2.How many bits are in a byte? A.6 or B.8 or C.16 or D.4: ","3.How many MB in a Gigga byte A.1024MB or B.2028MB or C.1024kb or D.3072: ","4.Define open source software A.It\"s an open bottle of ketchup or B.It\"s a free program OR C.It\"s a paid subscription or D.None of these: ","5.Which of these is an example of secondry? A.SSD or B.Cache or C.RAM or D.ROM: "}};

        static string[] Bio_answers = new string[5] { "A", "B", "B", "A", "A" };
        static string[] Phy_answers = new string[5] { "A", "A", "B", "A", "A" };
        static string[] Cs_answers = new string[5] { "A", "B", "A", "B", "A" };

        static void Main(string[] args)
        {
            string user_type, user_choice;

            Console.WriteLine("Are you a student or a teacher?: ");
            user_type = Console.ReadLine().ToLower();

            if (user_type == "student")
            {
                Console.WriteLine("Would you like to login or register?: ");
                user_choice = Console.ReadLine().ToLower();

                if (user_choice == "register")
                {
                    Register();
                }

                else if (user_choice == "login")
                {
                    Login();
                }

                else
                {
                    Console.WriteLine("Sorry that response isn\"t recognised");
                }
            }

            else if (user_type == "teacher")
            {

                Teacher();
            }

            else
            {
                Console.WriteLine("Sorry that response isn\"t recognised");
            }
        }

        static void Register()
        {
            string name, surname, age, username, password, filepath, userchoice;
            filepath = "username.csv";
            Console.WriteLine("Please enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine("Please enter your surname: ");
            surname = Console.ReadLine();
            Console.WriteLine("Please enter your age: ");
            age = Console.ReadLine();
            username = name.Substring(0, 3) + age;
            Console.WriteLine("Your username is " + username);
            Console.WriteLine("Please enter your password: ");
            password = Console.ReadLine();

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
            {
                file.WriteLine(name + "," + surname + "," + age + "," + username + "," + password);
            }
            Console.WriteLine("Would you like to login? Please enter your choice as yes or no.: ");
            userchoice = Console.ReadLine().ToLower();
            if (userchoice == "yes")
            {
                Login();

            }

        }
        static void Login() {
            while (true) {
                string username, filepath,topic, difficulty, rest;
                filepath = "username.csv";
                Console.WriteLine("Please enter your username: ");
                username = Console.ReadLine();

                if (Usercheck(filepath, username) == true)
                {
                    Console.WriteLine("Please enter your password: ");
                    password = Console.ReadLine();
                    if (Passwordcheck(filepath, password) == true)
                    {
                        Console.WriteLine("Hi, there have are 3 topics A.Biology, B.Computer Science, C.Physics.");
                        Console.WriteLine("What three topics would you like to be tested on? Please enter your choice as a and b, b and c ect: ");
                        topic = Console.ReadLine().ToLower();
                        Console.WriteLine("Hi, there have are 3 difficultys A.Easy two possible answers, B.Medium three possible anslwers, C.Hard four possible answers.");
                        Console.WriteLine("What difficulty would you like to be tested on? Please enter your choice as a, b, c.: ");
                        difficulty = Console.ReadLine().ToLower();

                        if (topic == "a and b")
                        {
                            Bio_CS(username, difficulty, topic);
                            break;
                        }

                        else if (topic == "a and c")
                        {
                            Bio_Phy(username, difficulty, topic);
                            break;
                        }

                        else if (topic == "b and c")
                        {
                            Phy_CS(username, difficulty, topic);
                            break;
                        }

                        else {
                            Console.WriteLine("Invalid response please try again.");
                        }
                    }

                    else {
                        Console.WriteLine("Incorrect password");
                    }
                }

                else if (Usercheck(filepath, username) == false){
                    Console.WriteLine("Incorrect username");
                }

                if (Usercheck(filepath, username) | Passwordcheck(filepath, password) == false) {
                    Console.WriteLine("Would you like to rest your username and password?. Please yes or no: ");
                    rest = Console.ReadLine().ToLower();

                    if (rest == "yes")
                    {
                        Rest(filepath, username, password);
                        break;
                    }

                    else {
                        break;
                    }
                }
            }
        }

        static void Teacher()
        {
            string username, password, filepath, user, pass;
            Console.WriteLine("PLease enter the teacher username: ");
            username = Console.ReadLine();
            user = "Admin";
            pass = "Admin123";

            if (user == username)
            {
                Console.WriteLine("Please enter your password: ");
                password = Console.ReadLine();
                if (pass == password)
                {
                    filepath = "score.csv";
                    string[] lines = System.IO.File.ReadAllLines(@filepath);
                    Console.WriteLine(String.Join(Environment.NewLine, lines));
                }
                else
                {
                    Console.WriteLine("Incorrect password");
                }
            }

            else {
                Console.WriteLine("Incorrect username");
            }
        }

        static void Bio_CS(string username, string difficulty, string topic)
        {
            string question;
            int score = 0;
            Console.WriteLine("There are 10 questions. 5 for each topic");
            Console.WriteLine("You will be quized on the bio questions first");

            int q1 = 0, a1 = 0, q2 = 0, a2 = 0;

            if (difficulty == "a")
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(Bio_questions[0, q1]);
                    question = Console.ReadLine().ToUpper();

                    if (question == (Bio_answers[a1]))
                    {
                        Console.WriteLine("correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("WRONG");
                    }

                    q1++;
                    a1++;
                }

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(Cs_questions[0, q2]);
                    question = Console.ReadLine().ToUpper();

                    if (question == (Cs_answers[a2]))
                    {
                        Console.WriteLine("correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("WRONG");
                    }

                    q2++;
                    a2++;
                }

            }
                if (difficulty == "b")
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine(Bio_questions[1, q1]);
                        question = Console.ReadLine().ToUpper();

                        if (question == (Bio_answers[a1]))
                        {
                            Console.WriteLine("correct");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine("WRONG");
                        }

                        q1++;
                        a1++;
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine(Cs_questions[1, q2]);
                        question = Console.ReadLine().ToUpper();

                        if (question == (Cs_answers[a2]))
                        {
                            Console.WriteLine("correct");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine("WRONG");
                        }

                        q2++;
                        a2++;
                    }
                }
                if (difficulty == "c")
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine(Bio_questions[2, q1]);
                        question = Console.ReadLine().ToUpper();

                        if (question == (Bio_answers[a1]))
                        {
                            Console.WriteLine("correct");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine("WRONG");
                        }

                        q1++;
                        a1++;
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine(Cs_questions[2, q2]);
                        question = Console.ReadLine().ToUpper();

                        if (question == (Cs_answers[a2]))
                        {
                            Console.WriteLine("correct");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine("WRONG");
                        }

                        q2++;
                        a2++;
                    }
                }
                
                SavetoFile(username, topic, difficulty, score);
            
        }

        static void Bio_Phy(string username, string difficulty, string topic) {
            string question;
            int score = 0;
            Console.WriteLine("There are 10 questions. 5 for each topic");
            Console.WriteLine("You will be quized on the bio questions first");

            int q1 = 0, a1 = 0, q2 = 0, a2 = 0;

            if (difficulty == "a")
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(Bio_questions[0, q1]);
                    question = Console.ReadLine().ToUpper();

                    if (question == (Bio_answers[a1]))
                    {
                        Console.WriteLine("correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("WRONG");
                    }

                    q1++;
                    a1++;
                }

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(Phy_questions[0, q2]);
                    question = Console.ReadLine().ToUpper();

                    if (question == (Phy_answers[a2]))
                    {
                        Console.WriteLine("correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("WRONG");
                    }

                    q2++;
                    a2++;
                }

            }
            if (difficulty == "b")
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(Bio_questions[1, q1]);
                    question = Console.ReadLine().ToUpper();

                    if (question == (Bio_answers[a1]))
                    {
                        Console.WriteLine("correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("WRONG");
                    }

                    q1++;
                    a1++;
                }

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(Phy_questions[1, q2]);
                    question = Console.ReadLine().ToUpper();

                    if (question == (Phy_answers[a2]))
                    {
                        Console.WriteLine("correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("WRONG");
                    }

                    q2++;
                    a2++;
                }
            }
            if (difficulty == "c")
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(Phy_questions[2, q1]);
                    question = Console.ReadLine().ToUpper();

                    if (question == (Phy_answers[a1]))
                    {
                        Console.WriteLine("correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("WRONG");
                    }

                    q1++;
                    a1++;
                }

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(Phy_questions[2, q2]);
                    question = Console.ReadLine().ToUpper();

                    if (question == (Phy_answers[a2]))
                    {
                        Console.WriteLine("correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("WRONG");
                    }

                    q2++;
                    a2++;
                }
            }

            SavetoFile(username, topic, difficulty, score);
        }

        static void Phy_CS(string username, string difficulty, string topic) {
            string question;
            int score = 0;
            Console.WriteLine("There are 10 questions. 5 for each topic");
            Console.WriteLine("You will be quized on the physics questions first");

            int q1 = 0, a1 = 0, q2 = 0, a2 = 0;

            if (difficulty == "a")
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(Phy_questions[0, q1]);
                    question = Console.ReadLine().ToUpper();

                    if (question == (Phy_answers[a1]))
                    {
                        Console.WriteLine("correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("WRONG");
                    }

                    q1++;
                    a1++;
                }

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(Cs_questions[0, q2]);
                    question = Console.ReadLine().ToUpper();

                    if (question == (Cs_answers[a2]))
                    {
                        Console.WriteLine("correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("WRONG");
                    }

                    q2++;
                    a2++;
                }
            }

            if (difficulty == "b")
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(Phy_questions[1, q1]);
                    question = Console.ReadLine().ToUpper();

                    if (question == (Phy_answers[a1]))
                    {
                        Console.WriteLine("correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("WRONG");
                    }

                    q1++;
                    a1++;
                }

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(Cs_questions[1, q2]);
                    question = Console.ReadLine().ToUpper();

                    if (question == (Cs_answers[a2]))
                    {
                        Console.WriteLine("correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("WRONG");
                    }

                    q2++;
                    a2++;
                }
            }
            
            if (difficulty == "c")
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(Phy_questions[2, q1]);
                    question = Console.ReadLine().ToUpper();

                    if (question == (Phy_answers[a1]))
                    {
                        Console.WriteLine("correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("WRONG");
                    }

                    q1++;
                    a1++;
                }

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(Cs_questions[2, q2]);
                    question = Console.ReadLine().ToUpper();

                    if (question == (Cs_answers[a2]))
                    {
                        Console.WriteLine("correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("WRONG");
                    }

                    q2++;
                    a2++;
                }
            }
            SavetoFile(username, topic, difficulty, score);
        }

        static void SavetoFile(string username, string difficulty, string topic, int score) {
            string filepath = "score.csv";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
            {
                file.WriteLine(username + "," + difficulty + "," + topic + "," + score);
            }
        }

        static bool Usercheck(string filepath, string username)
        {
            string[] lines = System.IO.File.ReadAllLines(@filepath);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(",");
                if (fields.Contains(username))
                {
                    Console.WriteLine("User found");
                    return true;
                }
            }
            return false;
        }

        static bool Passwordcheck(string filepath, string Password)
        {
            string[] lines = System.IO.File.ReadAllLines(@filepath);

            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(",");
                if (fields.Contains(Password))
                {
                    Console.WriteLine("Password found");
                    return true;
                }
            }
            return false;
        }

        static void Rest(string filepath, string username, string password) {
            string rest, name, findusername;

            Console.WriteLine("What would you like to change? A.Username or B.Password: ");
            rest = Console.ReadLine().ToLower();

            if (rest == "a")
            {
                Console.WriteLine("Please enter the name assosiated with the username: ");
                name = Console.ReadLine();
                
                string[] lines = System.IO.File.ReadAllLines(@filepath);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(",");
                    if (fields.Contains(name))
                    {
                        Console.WriteLine("Name located");

                        List<string> list = new List<string>(lines);
                        list.Sort();
                        list.Remove(lines[i]);
                        System.IO.File.WriteAllLines(@filepath, list);
                        Console.WriteLine("Now taking you to the registration form");

                        Register();
                    }
                }
            }

            else if (rest == "b")
            {
                Console.WriteLine("Please enter the username assosiated with the username: ");
                findusername = Console.ReadLine();

                string[] lines = System.IO.File.ReadAllLines(@filepath);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(",");
                    if (fields.Contains(findusername))
                    {
                        Console.WriteLine("Username located");

                        List<string> list = new List<string>(lines);
                        list.Sort();
                        list.Remove(lines[i]);
                        System.IO.File.WriteAllLines(@filepath, list);
                        Console.WriteLine("Now taking you to the registration form");

                        Register();
                    }
                }
            }

            else
            {
                Console.WriteLine("Invalid response");
            }
        }
    }
}