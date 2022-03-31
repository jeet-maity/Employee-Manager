using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace DataClient
{
    public class UsersDataClient : RestClient, IUsersDataClient
    {
        public UsersDataClient() : base("https://gorest.co.in/public-api/") { }

        protected string accessToken = @"fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56";

        public UserDTO GetByID(int id)
        {
            var request = new RestRequest("users/{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString());
            request.AddHeader("authorization", "bearer " + accessToken);
            request.RequestFormat = DataFormat.Json;
            var response = HandleRequest<ResponseDTO>(request);
            return response.Data.data.FirstOrDefault();
        }

        public List<UserDTO> GetAllUsers()
        {
            var request = new RestRequest("users", Method.GET);
            request.AddHeader("authorization", "bearer " + accessToken);
            request.RequestFormat = DataFormat.Json;
            var response = HandleRequest<ResponseDTO>(request);
            return response.Data.data;
        }

        public List<UserDTO> SearchUsersByName(string name)
        {
            var request = new RestRequest("users", Method.GET);
            request.AddQueryParameter("name", name, true);
            request.AddHeader("authorization", "bearer " + accessToken);
            request.RequestFormat = DataFormat.Json;
            var response = HandleRequest<ResponseDTO>(request);
            return response.Data.data;
        }

        public bool DeleteUser(int id)
        {
            RestRequest request = new RestRequest("users/{id}", Method.DELETE);
            request.AddUrlSegment("id", id.ToString());
            request.AddHeader("authorization", "bearer " + accessToken);
            request.RequestFormat = DataFormat.Json;
            var response = HandleRequest<ResponseDTO>(request);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public bool PatchExistingUser(UserDTO userDTO)
        {
            RestRequest request = new RestRequest("users/{id}", Method.PATCH);
            request.AddUrlSegment("id", userDTO.id.ToString());
            request.AddHeader("authorization", "bearer " + accessToken);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(userDTO);
            var response = HandleRequest<ResponseDTO>(request);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public bool PostNewUser(UserDTO userDTO)
        {
            RestRequest request = new RestRequest("users/{id}", Method.PATCH);
            request.AddUrlSegment("id", userDTO.id.ToString());
            request.AddHeader("authorization", "bearer " + accessToken);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(userDTO);
            var response = HandleRequest<ResponseDTO>(request);
            return response.StatusCode == HttpStatusCode.Created;
        }

        private IRestResponse<T> HandleRequest<T>(RestRequest request)
        {
            IRestResponse<T> response;
            try
            {
                response = Execute<T>(request);
            }
            catch (Exception ex)
            {
                throw new Exception($"error at back end - {ex}");
            }
            
            return response.StatusCode == HttpStatusCode.OK ? response : default;
        }
    }
}
