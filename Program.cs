List<string> nominatedNames = ["Lars", "Joakim"];
Election election = new Election(nominatedNames);


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/election/nominee", () =>
{
  return election.ListNominees();
});

app.MapPost("/election/vote", (VoteDTO vote) =>
{
  Vote? voteReciept = election.CastVote(vote.Nominee);

  if (voteReciept == null)
  {
    return Results.BadRequest();
  }
  else
  {
    return Results.Ok();
  }
});

app.Run();
