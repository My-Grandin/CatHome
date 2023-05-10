using CatHome.Domain.Entities;
using CatHome.Domain.Repositories;
using CatHome.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatHome.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly string _filePathForMembers = @"../CatHome.Infrastructure/members.json";

        private readonly JsonContext _context;

        public MemberRepository(JsonContext context)
        {
            _context = context;
        }
        public async Task<bool> MemberExists(int id)
        {
            var members = await _context.DeserializeJsonFile<Member>(_filePathForMembers);
            return members.Any(m => m.Id == id);
        }
    }
}
