using GraphQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using GraphQLDemo.Data;
using GraphQLDemo.GraphQL;
using GraphQLDemo.GraphQL.Inputs;
using GraphQLDemo.GraphQL.Mutations;
using GraphQLDemo.GraphQL.Queries;
using GraphQLDemo.GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

// �T�[�r�X�̓o�^
builder.Services.AddSingleton<BookRepository>();
builder.Services.AddScoped<BookQuery>();
builder.Services.AddScoped<BookType>();
builder.Services.AddScoped<BookMutation>();
builder.Services.AddScoped<BookInputType>();
builder.Services.AddScoped<ISchema, BookSchema>();

// GraphQL�̐ݒ�
builder.Services.AddGraphQL(b => b
    .AddAutoSchema<BookQuery>()  // schema
    .AddSystemTextJson());   // serializer

// �R���g���[���[�̒ǉ�
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();

// GraphQL �G���h�|�C���g�̐ݒ�
app.UseGraphQL<ISchema>();

// Playground �̐ݒ�
app.UseGraphQLPlayground("/teiteidemo", new PlaygroundOptions());

// �G���h�|�C���g�̃}�b�s���O
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();