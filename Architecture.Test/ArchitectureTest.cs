using NetArchTest.Rules;
using FluentAssertions;
using static System.Net.Mime.MediaTypeNames;

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

        [Fact]
        public void Application_Should_Not_HaveDependeciesToAthereProjects()
        {
            // Arrange
            var domainAssemble = typeof(Application.AssemblyReference).Assembly;
            var othereProjets = new[]
            {
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

        [Fact]
        public void Infrastrucutre_Should_Not_HaveDependeciesToAthereProjects()
        {
            // Arrange
            var domainAssemble = typeof(Infrastructure.AssemblyReference).Assembly;
            var othereProjets = new[]
            {
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

        [Fact]
        public void Presentatio_Should_Not_HaveDependeciesToAthereProjects()
        {
            // Arrange
            var domainAssemble = typeof(Presentation.AssemblyReference).Assembly;
            var othereProjets = new[]
            {
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