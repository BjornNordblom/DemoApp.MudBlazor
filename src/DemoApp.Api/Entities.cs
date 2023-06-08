public enum DebtorInvolvement
{
    Principal = 1,
    Guarantor = 2,
    CoDebtor = 3
}

[ValueObject<int>]
public partial struct ActId { }

[ValueObject<int>]
public partial struct DebtorId { }

[ValueObject<decimal>]
public partial struct Amount { }

public class Act
{
    ActId ActId { get; set; }
    string ReferenceNumber { get; set; } = "";
    Amount Amount { get; set; } = default!;
    public ICollection<ActDebtor> ActDebtors { get; set; } = default!;
}

public class ActDebtor
{
    public ActId ActId { get; set; }
    public Act Act { get; set; } = default!;
    public DebtorId DebtorId { get; set; }
    public Debtor Debtor { get; set; } = default!;
    public DebtorInvolvement Involvement { get; set; } = default!;
}

public class Debtor
{
    public DebtorId DebtorId { get; set; }
    public string Name { get; set; } = "";
}
