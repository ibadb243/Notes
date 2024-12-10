using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.CreateCommand;
using Notes.Application.Notes.Commands.UpdateCommand;

namespace Notes.WebApi.Models
{
    public class UpdateNoteDto : IMapWith<UpdateNoteCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteCommand, UpdateNoteDto>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(cmd => cmd.Id))
                .ForMember(dto => dto.Title,
                    opt => opt.MapFrom(cmd => cmd.Title))
                .ForMember(dto => dto.Details,
                    opt => opt.MapFrom(cmd => cmd.Details));
        }
    }
}
