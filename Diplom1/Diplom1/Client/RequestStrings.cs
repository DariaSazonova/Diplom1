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
        public static string getRating(int idApplicant, int idTest=0)
        {
            return $"{client}/QuestRating/{idApplicant}?idTest={idTest}";
        }
        public static string getAbbRating(int level, int id)
        {
            return $"{client}/AddRating?level={level}&applicantid={id}";
        }
        public static string postUser(string login, string password)
        {
            return $"{client}/User?Login={login}&Password={password}&Role=applicant";
        }
        public static string postApplicant(string IdApplicants, string Surname, string Name, string Patronymic, string Phone, string Email, string DateOfBirth)
        {
            return $"{client}/Applicant?IdApplicants={IdApplicants}&Surname={Surname}&Name={Name}&Patronymic={Patronymic}&Phone={Phone}&Email={Email}&DateOfBirth={DateOfBirth}";
        }
        public static string putQuestions()
        {
            return $"{client}/questquestions/";
        }
        public static string getChart(int month)
        {
            return $"{client}/countab?month={month}";
        }
        public static string getMediaFiles(string type = "file") { return $"{client}/mediafile?type={type}"; }
        public static string getPhotos = $"{client}/photos/";
        public static string putmediafile = $"{client}/mediafile/";

    }
}
