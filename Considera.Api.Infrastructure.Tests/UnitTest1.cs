namespace Considera.Api.Infrastructure.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests
{
    [Test]
    public Task IsEven()
    {
        Assert.That(2 == 2 && 2 % 2 == 0);
        return Task.CompletedTask;
    }
}