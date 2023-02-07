using GraphQL.Types;

namespace MyMicroservice.Notes
{
    public class NotesQuery:ObjectGraphType
    {
        public NotesQuery() 
        {
            Field<ListGraphType<NoteType>>("notes", resolve: context => new List<Note>
            {
                new Note{ Id = Guid.NewGuid(), Message="Hello world!"},
                new Note{ Id = Guid.NewGuid(), Message="Hello world! How are you?"},
            });
        }
    }
}
