using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Diplom1.Client
{
    public class PreferencesApp
    {
        public static string State
        {
            get { return Preferences.Get("state", ""); }
            set
            {
                if (findState())
                {
                    Preferences.Remove("state");
                }
                Preferences.Set("state", value);
            }
        }

        public static bool findState()
        {
            return Preferences.ContainsKey("state");
        }

        // State Preference

        public static string Login
        {
            get { return Preferences.Get("login", ""); }
            set
            {
                if (findLogin())
                {
                    Preferences.Remove("login");
                }
                Preferences.Set("login", value);
            }
        }

        public static bool findLogin()
        {
            return Preferences.ContainsKey("login");
        }
        // Login Preference


        public static string Password
        {
            get { return Preferences.Get("password", ""); }
            set
            {
                if (findPassword())
                {
                    Preferences.Remove("password");
                }
                Preferences.Set("password", value);
            }
        }

        public static bool findPassword()
        {
            return Preferences.ContainsKey("password");
        }

        // Password Preference

        public static string UserID
        {
            get { return Preferences.Get("userID", ""); }
            set
            {
                if (findUserID())
                {
                    Preferences.Remove("userID");
                }
                Preferences.Set("userID", value);
            }
        }
        public static bool findUserID()
        {
            return Preferences.ContainsKey("userID");
        }
        public static string role
        {
            get { return Preferences.Get("role", ""); }
            set
            {
                if (findRole())
                {
                    Preferences.Remove("role");
                }
                Preferences.Set("role", value);
            }
        }
        public static bool findRole()
        {
            return Preferences.ContainsKey("role");
        }

        public static string Surname
        {
            get { return Preferences.Get("Surname", ""); }
            set
            {
                if (findSurname())
                {
                    Preferences.Remove("Surname");
                }
                Preferences.Set("Surname", value);
            }
        }

        public static bool findSurname()
        {
            return Preferences.ContainsKey("Surname");
        }

        public static string Name
        {
            get { return Preferences.Get("Name", ""); }
            set
            {
                if (findName())
                {
                    Preferences.Remove("Name");
                }
                Preferences.Set("Name", value);
            }
        }

        public static bool findName()
        {
            return Preferences.ContainsKey("Name");
        }

        public static string Patronymic
        {
            get { return Preferences.Get("Patronymic", ""); }
            set
            {
                if (findPatronymic())
                {
                    Preferences.Remove("Patronymic");
                }
                Preferences.Set("Patronymic", value);
            }
        }

        public static bool findPatronymic()
        {
            return Preferences.ContainsKey("Patronymic");
        }
        public static string Phone
        {
            get { return Preferences.Get("Phone", ""); }
            set
            {
                if (findPhone())
                {
                    Preferences.Remove("Phone");
                }
                Preferences.Set("Phone", value);
            }
        }

        public static bool findPhone()
        {
            return Preferences.ContainsKey("Phone");
        }
        public static string DateOfBirth
        {
            get { return Preferences.Get("DateOfBirth", ""); }
            set
            {
                if (findDateOfBirth())
                {
                    Preferences.Remove("DateOfBirth");
                }
                Preferences.Set("DateOfBirth", value);
            }
        }

        public static bool findDateOfBirth()
        {
            return Preferences.ContainsKey("DateOfBirth");
        }

    }
}
