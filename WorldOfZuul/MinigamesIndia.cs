public void SewagePlantQuiz(ref int score)
        {
            // Contextual Minigame Introduction
            Console.ForegroundColor = ConsoleColor.Cyan;
            helper.WriteWithDelay("\nYou go inside the tank room and inspect the damage.");
            helper.WriteWithDelay("\nThe pipes are clogged. There are pumps, valves and sensors that are in need of replacement. At least the tanks themselves are intact. It would have been a lot worse had you needed to replace them too.");
            helper.WriteWithDelay("\nIt looks like you have your work cut out for you.");
            Console.ResetColor();

            // Questions for the Minigame
            List<Question> questions = new List<Question>
    {
        new Question
        {
            Text = "What is the primary purpose of a sewage treatment plant?",
            Options = new Dictionary<char, string>
            {
                { 'A', "To generate electricity." },
                { 'B', "To treat wastewater and remove contaminants." },
                { 'C', " To provide drinking water." },
                { 'D', "To manage stormwater." }
            },
            CorrectOption = 'B',
            Explanation = "The main goal of a sewage treatment plant is to eliminate pollutants from wastewater, resulting in clean, safe water for discharge or reuse."
        },
        new Question
        {
            Text = "True or False: Proper sewage treatment can help prevent waterborne diseases.",
            Options = new Dictionary<char, string>
            {
                { 'A', "True." },
                { 'B', "False." },
            },
            CorrectOption = 'A',
            Explanation = "Waterborne diseases are caused by the viruses and bacteria in dirty water. The more people consume the filtered water that has gone through sewage treatment, the more the percentage of them will get sick."
        },
        new Question
        {
            Text = "Which of the following is a key indicator for measuring progress towards SDG Goal 6?",
            Options = new Dictionary<char, string>
            {
                { 'A', "Percentage of population using clean water." },
                { 'B', "Number of new dams constructed." },
                { 'C', "Amount of water used per capita." },
                { 'D', "Total length of rivers in a country." }
            },
            CorrectOption = 'A',
            Explanation = "With the increase of locals using safe and clean water, we're getting closer to the completion of our goal in India."
        },
        new Question
        {
            Text = "Which of the following is a major challenge for water management in India?",
            Options = new Dictionary<char, string>
            {
                { 'A', "Over-extraction of groundwater." },
                { 'B', "Pollution of water bodies." },
                { 'C', "Inefficient water use in agriculture." },
                { 'D', "All of the above." }
            },
            CorrectOption = 'D',
            Explanation = "All three of the aforementioned are the reason why India has a severe lack of clean water."
        },
    };

            int minigameScore = 0;
            int questionNumber = 1;

            foreach (var question in questions)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                helper.WriteWithDelay($"Question {questionNumber}: {question.Text}");
                Console.ResetColor();

                foreach (var option in question.Options)
                {
                    Console.Write($"{option.Key}. ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(option.Value);
                    Console.ResetColor();
                }

                Console.Write("\nEnter your choice (A, B, C, or D): ");
                char playerChoice = GetValidOption();

                if (char.ToUpper(playerChoice) == question.CorrectOption)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct! " + question.Explanation);
                    score++;
                    minigameScore++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Incorrect. Correct Answer: {question.CorrectOption}. {question.Options[question.CorrectOption]}");
                    Console.WriteLine(question.Explanation);
                }

                Console.ResetColor();
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                questionNumber++;
            }

            // Final Minigame Results
            Console.ForegroundColor = ConsoleColor.Blue;
            helper.WriteWithDelay($"\nGame Over! You scored {score}/{questions.Count}.");
            if (score == questions.Count)
                helper.WriteWithDelay("You found all the tools that you'll need. Then you proceeded to fix or replace all of the valves," +
                " pipes and sensors. Afterwards you managed to unclog the pipes and finally did a systems check to see if everything is operational once more. And it is, thanks to you.");
            else if (score >= questions.Count / 2)
                helper.WriteWithDelay("You found all the tools that you'll need. You managed to unclog the pipes but just barely and you couldn't do anything with the valves, pipes and sensors." +
                "Perhaps it's better if you refresh your memory and then try again.");
            else
                helper.WriteWithDelay("There's a lot that you haven't learn yet. Come back again.");
            Console.ResetColor();

        }
