using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Linq.Expressions;
using BoardsApp.Entities;
using Microsoft.EntityFrameworkCore.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BoardsAppContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("BoardsAppConnectionString"))
    );

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<BoardsAppContext>();

app.MapGet("Questions", async (BoardsAppContext db) => {

    var questions = await db.Question
    .OrderByDescending(x => x.CreatedDate)
    .ToListAsync();

    return questions;
});

app.MapGet("Answers", async (BoardsAppContext db) => {

    var answers = await db.Answers
    .OrderByDescending(x => x.CreatedDate)
    .ToListAsync();

    return answers;
});

app.MapPost("Answers", async (BoardsAppContext db) => {

    var answer = new Answer()
    {
        Message = "test nessage",
        CreatedDate = DateTime.Now,
        UpdateDate = DateTime.Now,
        QuestionId = 1,
        UserId = 2
    };

    dbContext.Answers.Add(answer);
    dbContext.SaveChanges();
});

app.MapPost("Questions", async (BoardsAppContext db) => {

    var question = new Question()
    {
       Value = "test value",
       CreatedDate = DateTime.Now,
       UpdateDate = DateTime.Now,
       UserId = 1
    };

    dbContext.Question.Add(question);
    dbContext.SaveChanges();
});

app.MapPost("AddScoreToAnswers", async (int answerId, int userId, AnswerLike like, BoardsAppContext db) => {

    var answer = await db.Answers.FindAsync(answerId);
    if (answer == null) return Results.NotFound("OdpowiedŸ nie istnieje.");

    var newLike = new AnswerLike
    {
        AnswerId = answerId,
        UserId = userId,
        IsUpvote = like.IsUpvote
    };

    dbContext.Scores.Add(newLike);
    dbContext.SaveChanges();

    return Results.Ok("G³os zapisany.");
});

app.MapGet("Answer/Likes", async (BoardsAppContext db, int id) => {

var score = await db.Scores
.Where(s => s.AnswerId == id)
.SumAsync(s => s.IsUpvote ? 1 : -1);

return Results.Ok(new { AnswerId = id, Score = score });
});

app.Run();
