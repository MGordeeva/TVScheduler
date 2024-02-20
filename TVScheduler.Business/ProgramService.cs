using AutoMapper;
using TVScheduler.Business.Helpers;
using TVScheduler.Business.Interfaces;
using TVScheduler.DataAccess;
using TVScheduler.DataAccess.Dto;
using TVScheduler.WebApi.Models;

namespace TVScheduler.Business
{
    public class ProgramService : IProgramService
    {
        private readonly IProgramRepository _programRepository;
        private readonly IMapper _mapper;

        public ProgramService(IProgramRepository programRepository, IMapper mapper)
        {
            _programRepository = programRepository;
            _mapper = mapper;
        }

        public async Task CreateProgramAsync(int channelId, CreateProgramRequest programModel)
        {
            var program = _mapper.Map<Program>(programModel);
            programModel.StartTime = DateTimeHelper.TrimMilliseconds(programModel.StartTime);
            programModel.EndTime = DateTimeHelper.TrimMilliseconds(programModel.EndTime);

            await _programRepository.CreateProgramAsync(channelId, program);
        }

        public async Task DeleteProgramAsync(int channelId, int id)
        {
            await _programRepository.DeleteProgramAsync(channelId, id);
        }

        public async Task<Program?> GetProgramByIdAsync(int channelId, int programId)
        {
            return await _programRepository.GetProgramByIdAsync(channelId, programId);
        }

        public async Task<IEnumerable<Program>> GetProgramsByChannelAsync(int channelId, DateTime? startTime, DateTime? endTime)
        {
            return await _programRepository.GetProgramsByChannelAsync(channelId, startTime, endTime);
        }
    }
}