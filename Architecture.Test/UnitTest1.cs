using NetArchTest.Rules;
using FluentAssertions;

namespace Architecture.Test
{
    public class ArchitectureTests
    {
        private const string DomainProjectNameSpace = "Domain";
        private const string ApplicationProjectNameSpace= "Application";
        private const string InfrastructureNameSpace= "Infrastructure";
        private const string PresentationNameSpace = "Presentation";
        private const string WebProjectNameSpace = "Web";

        [Fact]
        public void Domain_Should_Not_HaveDependeciesToAthereProjects()
        {
            // Arrange
            var domainAssemble = typeof(Domain.AssemblyReference).Assembly;
            var othereProjets = new[]
            {
                ApplicationProjectNameSpace,
                InfrastructureNameSpace,
                PresentationNameSpace,
                WebProjectNameSpace
            };
            //act

           var result = Types
                .InAssembly(domainAssemble)
                .ShouldNot()
                .HaveDependencyOnAny(othereProjets)
                .GetResult();
            // Assert

            result.IsSuccessful.Should().BeTrue();
        }
    }
}