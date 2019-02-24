using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestSharp;
using GeekHunters.App.Repositories.Interfaces;
using GeekHunters.App.Models;
using Newtonsoft.Json;

namespace GeekHunters.App.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly IConfigRepository _configRepository;

        public CandidateRepository(IOptions<ConfigRepository> config)
        {
            _configRepository = config.Value;
        }

        public async Task<IEnumerable<Candidate>> GetCandidates()
        {
            var client = new RestClient(((ConfigRepository)_configRepository).GeekHuntersEndPoint);
            var request = new RestRequest("/api/candidates", Method.GET);

            IRestResponse<IEnumerable<Candidate>> response = await client.ExecuteTaskAsync<IEnumerable<Candidate>>(request);
            return response.Data;
        }

        public async Task<Candidate> GetCandidate(int id)
        {
            var client = new RestClient(((ConfigRepository)_configRepository).GeekHuntersEndPoint);
            var request = new RestRequest($"/api/candidates/{id}", Method.GET);

            IRestResponse<Candidate> response = await client.ExecuteTaskAsync<Candidate>(request);
            return response.Data;
        }

        public async Task<IEnumerable<Candidate>> GetCandidatesBySkillId(int id)
        {
            var client = new RestClient(((ConfigRepository)_configRepository).GeekHuntersEndPoint);
            var request = new RestRequest($"/api/candidates/skills/{id}", Method.GET);

            IRestResponse<IEnumerable<Candidate>> response = await client.ExecuteTaskAsync<IEnumerable<Candidate>>(request);
            return response.Data;
        }

        public async Task<bool> UpdateCandidate(Candidate candidate)
        {
            var client = new RestClient(((ConfigRepository)_configRepository).GeekHuntersEndPoint);
            var request = new RestRequest($"/api/candidates/{candidate.Id}", Method.PUT);
            request.AddParameter(new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(candidate)
            });

            IRestResponse response = await client.ExecuteTaskAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Skill>> GetSkills()
        {
            var client = new RestClient(((ConfigRepository)_configRepository).GeekHuntersEndPoint);
            var request = new RestRequest("/api/candidates/skills", Method.GET);

            IRestResponse<List<Skill>> response = await client.ExecuteTaskAsync<List<Skill>>(request);
            return response.Data;
        }

        public async Task<int> AddCandidate(Candidate candidate)
        {
            var client = new RestClient(((ConfigRepository)_configRepository).GeekHuntersEndPoint);
            var request = new RestRequest("/api/candidates", Method.POST);
            request.AddParameter(new Parameter
            {
                Name = "application/json",
                Type = ParameterType.RequestBody,
                Value = JsonConvert.SerializeObject(candidate)
            });

            IRestResponse response = await client.ExecuteTaskAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                int.TryParse(response.Content, out int retid);
                return retid;
            }
            else
            {
                return 0;
            }
        }

        public async Task<bool> DeleteCandidate(int id)
        {
            var client = new RestClient(((ConfigRepository)_configRepository).GeekHuntersEndPoint);
            var request = new RestRequest($"/api/candidates/{id}", Method.DELETE);

            IRestResponse response = await client.ExecuteTaskAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
