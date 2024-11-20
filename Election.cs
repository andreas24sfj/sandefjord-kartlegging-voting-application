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