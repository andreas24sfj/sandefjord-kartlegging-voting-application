class Election
{
  // Data
  List<Nominee> nominees;
  List<Vote> castVote;

  public Election(List<string> nomineeNames)
  {
    nominees = new List<Nominee>();
    castVote = new List<Vote>();

    foreach (var name in nomineeNames)
    {
      Nominee nominee = new Nominee(name);
      nominees.Add(nominee);
    }
  }

  public List<Nominee> ListNominees()
  {
    return nominees;
  }

  public Vote? CastVote(string nomineeName)
  {
    Nominee? nominee = nominees.Find((nominee) => nominee.Name == nomineeName);
    if (nominee == null)
    {
      return null;
    }

    Vote newVote = new Vote(nominee);
    castVote.Add(newVote);

    return newVote;
  }

  public Result GetCurrentResult()
  {
    Result result = new Result(castVote);
    return result;
  }
}

class Nominee
{
  public string Name { get; set; }

  public Nominee(string name)
  {
    Name = name;
  }
}

class Vote
{
  public DateTime CastAt { get; set; }
  public Nominee CastFor { get; set; }

  public Vote(Nominee nominee)
  {
    CastFor = nominee;
    CastAt = DateTime.Now;
  }
}

class Result
{
  public Dictionary<string, int> nomineesVoteCount { get; set; }

  public Result(List<Vote> votes)
  {
    nomineesVoteCount = new Dictionary<string, int>();

    foreach (var vote in votes)
    {
      if (!nomineesVoteCount.ContainsKey(vote.CastFor.Name))
      {
        nomineesVoteCount.Add(vote.CastFor.Name, 1);
      }
      else
      {
        nomineesVoteCount[vote.CastFor.Name] += 1;
      }
    }
  }
}