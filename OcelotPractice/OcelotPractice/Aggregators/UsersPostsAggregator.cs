﻿using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using OcelotPractice.Dtos;
using System.Net;
using System.Net.Http.Headers;

namespace OcelotPractice.Aggregators
{
    public class UsersPostsAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var userResponseContent = await responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
            var postResponseContent = await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();

            var users = JsonConvert.DeserializeObject<List<User>>(userResponseContent);
            var posts = JsonConvert.DeserializeObject<List<Post>>(postResponseContent);

            foreach (var user in users)
            {
                var userPosts = posts.Where(p => p.UserId == user.Id).ToList();
                user.Posts.AddRange(userPosts);
            }


            var postByUserString = JsonConvert.SerializeObject(users);
            var stringContent = new StringContent(postByUserString) { 
                Headers = { ContentType = new MediaTypeHeaderValue("application/json")}
            };


            return new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");

        }
    }
}
