namespace AutoProjektBusiness.Shared;

public class CanResult
{

    public bool Can { get; set; }

    public string Reason { get; set; }


    private CanResult(bool can, string reason)
    {
      Can = can;
      Reason = reason;
    }

    public static CanResult Success()
    {
      return new CanResult(true, "Erfolgreich");
    }

    public static CanResult Fail(string reason)
    {
      return new CanResult(false, reason);
    }



}
