using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class NoteDetailsVm : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note,  NoteDetailsVm>()
                .ForMember(vm => vm.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(vm => vm.Title,
                    opt => opt.MapFrom(note => note.Title))
                .ForMember(vm => vm.Details,
                    opt => opt.MapFrom(note => note.Details))
                .ForMember(vm => vm.CreatedAt,
                    opt => opt.MapFrom(note => note.CreatedAt))
                .ForMember(vm => vm.UpdatedAt,
                    opt => opt.MapFrom(note => note.UpdatedAt));
        }
    }
}