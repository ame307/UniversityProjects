using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWar.Global;
using WordWar.Model;

namespace WordWar.Handler
{
    class RequestHandler
    {
        String URL = "http://localhost/RESTAPI/";
        String ROUTE = "index.php";

        public List<User> GetHighScores()
        {
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE, Method.GET);
            IRestResponse<List<User>> response = client.Execute<List<User>>(request);
            List<User> top = new List<User>();
            for (int i = 0; i < 8; i++)
            {
                top.Add(response.Data[i]);
            }
            return top;
        }

        public User GetUserByName(string name)
        {
            var client = new RestClient(URL);
            String ROUTE = $"index.php?name={name}";
            var request = new RestRequest(ROUTE, Method.GET);
            IRestResponse<List<User>> response = client.Execute<List<User>>(request);
            try
            {
                return response.Data[0];
            }
            catch (ArgumentOutOfRangeException e)
            {
                return null;
            }
        }

        public string RegistrateNewUser(User user)
        {
            if (GetUserByName(user.Username) != null)
                return "Ez a felhasználónév már foglalt!";
            else
            {
                if (user.Username.Length > 0 && user.Password.Length > 0)
                {
                    var client = new RestClient(URL);
                    var request = new RestRequest(ROUTE, Method.POST);
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(user);
                    var response = client.Execute(request);
                    return "Sikeres regisztráció!";
                }
                else
                    return "Adjon meg felhasználónevet és jelszót!";
            }
        }

        public void UpdateHighScore()
        {
            var client = new RestClient(URL);
            String ROUTE = $"index.php?name={Globals.localUser.Username}";
            var request = new RestRequest(ROUTE, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(Globals.localUser);
            var response = client.Execute(request);
        }

        public string DeleteAccount()
        {
            var client = new RestClient(URL);
            String ROUTE = "index.php/{name}";
            var request = new RestRequest(ROUTE, Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(Globals.localUser);
            IRestResponse response = client.Execute(request);
            return "Az accountod törölve!";
        }
    }
}
