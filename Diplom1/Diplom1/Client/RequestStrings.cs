using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diplom1.Client
{
    public class GetClientConnection
    {
        public static bool CheckConnection()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
    public static class RequestStrings
    {
        public static readonly string client = "http://specialtyadvertising.somee.com/api";
        public static  string user(string login, string password)
        {
            return $"{client}/user/{login}/{password}";
        }
        public static string applicant(string login)
        {
            return $"{client}/applicant/{login}";
        }
        public static string admin(string login)
        {
            return $"{client}/admin/{login}";
        }
        public static string getQuestions(int i)
        {
            return $"{client}/questquestions/{i}";
        }
        public static string postQuestResult = $"{client}/QuestRating";
        public static string getRating(int idApplicant)
        {
            return $"{client}/QuestRating/{idApplicant}";
        }

    }
}
