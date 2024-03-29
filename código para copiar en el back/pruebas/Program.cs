﻿using SelectPdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            //axios start timer 
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            string sentencesWithoutPunctuation = new string(sentences.Where(c => !char.IsPunctuation(c)).ToArray());
            string[] words = sentencesWithoutPunctuation.Split(' ');

            int amountOfMatchingKeywordsX02 = 0;
            int amountOfMatchingKeywordsX03 = 0;
            int amountOfMatchingKeywordsX04 = 0;

            double chatbotWordsScore = 0;

            //keywords
            foreach (var word in words)
            {
                if (word == "miserable" ||
                    word == "despreciable" ||
                    word == "siempre" ||
                    word == "constantemente" ||
                    word == "nunca" ||
                    word == "jamás" ||
                    word == "jamas" ||
                    word == "insomnio" ||
                    word == "despierto" ||
                    word == "despierta" ||
                    word == "sueño" ||
                    word == "culpa" ||
                    word == "falta" ||
                    word == "responsabilidad")
                {
                    amountOfMatchingKeywordsX02++;
                }
                else if (word == "solitario" ||
                    word == "solitaria" ||
                    word == "solo" ||
                    word == "sola" ||
                    word == "soledad" ||
                    word == "abandono" ||
                    word == "abandonado" ||
                    word == "abandonada" ||
                    word == "triste" ||
                    word == "tristeza" ||
                    word == "enfadado" ||
                    word == "enfadada" ||
                    word == "cabreado" ||
                    word == "cabreada" ||
                    word == "odio" ||
                    word == "solución" ||
                    word == "solucion" ||
                    word == "remedio" ||
                    word == "esperanza")
                {
                    amountOfMatchingKeywordsX03++;
                }
                else if (word == "deprimido" ||
                    word == "deprimida" ||
                    word == "depresión" ||
                    word == "depresion" ||
                    word == "enfermo" ||
                    word == "enferma" ||
                    word == "bajón" ||
                    word == "bajon" ||
                    word == "morir" ||
                    word == "matarme" ||
                    word == "muerte" ||
                    word == "suicidio")
                {
                    amountOfMatchingKeywordsX04++;
                }

            }
            chatbotWordsScore = amountOfMatchingKeywordsX02 * 0.2 + (amountOfMatchingKeywordsX03 * 0.3) + (amountOfMatchingKeywordsX04 * 0.4);


            if (chatbotWordsScore >= 3)
            {
                //stopwatch
                stopWatch.Stop();
                TimeSpan elapsedTime = stopWatch.Elapsed;

                chatbotWordsScore = 3;
                //double chatbotScore = ChatbotScoreCalculation(words, chatbotWordsScore, elapsedTime);
            }
            else if (words.Length > 200)
            {
                //stopwatch
                stopWatch.Stop();
                TimeSpan elapsedTime = stopWatch.Elapsed;

                //double chatbotScore = ChatbotScoreCalculation(words, chatbotWordsScore, elapsedTime);
            }


            static double ChatbotScoreCalculation(Array words, double chatbotWordsScore, TimeSpan elapsedTime)
            {
                int amountOfFirstPersonSingularPronouns = 0;
                int amountOfOtherPronouns = 0;
                double chatbotScore;
                double chatbotPatternsScore = 0;

                foreach (string word in words)
                {
                    //pronouns
                    if (word == "yo" ||
                        word == "mi" ||
                        word == "me" ||
                        word == "conmigo")
                    {
                        amountOfFirstPersonSingularPronouns++;
                    }
                    else if (word == "tú" ||
                        word == "tu" ||
                        word == "te" ||
                        word == "ti" ||
                        word == "contigo" ||
                        word == "él" ||
                        word == "ella" ||
                        word == "ellos" ||
                        word == "ellas" ||
                        word == "les" ||
                        word == "las" ||
                        word == "vosotros" ||
                        word == "vosotras" ||
                        word == "os" ||
                        word == "usted" ||
                        word == "ustedes")
                    {
                        amountOfOtherPronouns++;
                    }
                }
                if (amountOfFirstPersonSingularPronouns > amountOfOtherPronouns)
                {
                    chatbotPatternsScore = +1;
                }

                //rumination
                Dictionary<string, int> dictionary = new Dictionary<string, int>();
                List<string> wordsList = new List<string>();
                foreach (string word in words)
                {
                    if (word.Length >= 3 && word != "muy" && word != "con" && word != "que" && word != "las" && word != "los" && word != "por" && word != "nos" && word != "mis" && word != "está" && word != "esta" && word != "todo")
                    {
                        wordsList.Add(word);
                    }
                }
                for (int i = 0; i < wordsList.Count; i++)
                {
                    if (dictionary.ContainsKey(wordsList[i])) // if word already exist in dictionary update the count  
                    {
                        int amount = dictionary[wordsList[i]];
                        dictionary[wordsList[i]] = amount + 1;
                    }
                    else
                    {
                        dictionary.Add(wordsList[i], 1);  // if a string is not added in dictionary, add it
                    }
                }
                bool rumination = false;
                foreach (KeyValuePair<string, int> kvp in dictionary)
                {
                    Console.WriteLine(kvp.Key + " = " + kvp.Value);
                    if (kvp.Value > (words.Length * 2.2 / 100))
                    {
                        rumination = true;
                    }
                }
                if (rumination)
                {
                    chatbotPatternsScore = +1;
                }

                //stopwatch
                double minutes = elapsedTime.TotalSeconds / 60;
                if (minutes >= 7)
                {
                    chatbotPatternsScore = +1;
                }

                //final score
                chatbotScore = chatbotWordsScore + chatbotPatternsScore;
                return chatbotScore;
            }


            /*//front
            static void TotalScore(double chatbotScore)
            {
                string evaluation = string.Empty;
                *//*axios questionsscore*//*
                //double totalScore = chatbotScore + questionsScore;
                //if (totalscore < 5)
                //{
                evaluation = "no se aprecian rasgos depresivos.";
                //}
                //else if (totalscore > 5 && totalscore < 10)
                //{
                //evaluation = "rasgos depresivos leves, se recomienda consultar con un especialista.";
                //}
                //else if (totalscore > 10 && totalscore <= 15)
                //{
                //    evaluation = "rasgos depresivos severos. es necesaria la consulta urgente con un especialista.";
                //}


            }*/

        }
    }
}
