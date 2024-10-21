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

// サービスの登録
builder.Services.AddSingleton<BookRepository>();
builder.Services.AddScoped<BookQuery>();
builder.Services.AddScoped<BookType>();
builder.Services.AddScoped<BookMutation>();
builder.Services.AddScoped<BookInputType>();
builder.Services.AddScoped<ISchema, BookSchema>();

// GraphQLの設定
builder.Services.AddGraphQL(b => b
    .AddAutoSchema<BookQuery>()  // schema
    .AddSystemTextJson());   // serializer

// コントローラーの追加
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();

// GraphQL エンドポイントの設定
app.UseGraphQL<ISchema>();

// Playground の設定
app.UseGraphQLPlayground("/teiteidemo", new PlaygroundOptions());

// エンドポイントのマッピング
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();