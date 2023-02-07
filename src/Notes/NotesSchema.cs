using GraphQL.Types;

namespace MyMicroservice.Notes
{
    public class NotesSchema: Schema
    {
        public NotesSchema(IServiceProvider serviceProvider): base(serviceProvider) 
        {
            Query = serviceProvider.GetRequiredService<NotesQuery>();

        }
    }
}
