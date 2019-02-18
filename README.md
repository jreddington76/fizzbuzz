# fizzbuzz
A  .NET Core TDD version of the classic interview question

Fizzbuzz version number: c52851081674597ecf5d5a4ed3bf750b39e3f8e5


Built on .NET Core:
  SDK version 2.2.102
  Host version 2.2.1



mkdir fizzbuzz
cd fizzbuzz

mkdir "FizzBuzz Step 1"
cd "FizzBuzz Step 1"

mkdir src
cd src

`dotnet new classlib -n FizzBuzz`


cd ..

mkdir tests
cd tests

`dotnet new xunit -n FizzBuzz.UnitTests`

cd FizzBuzz.UnitTests

`dotnet add reference ../../src/FizzBuzz/FizzBuzz.csproj`
`dotnet add package moq`


cd ..

`dotnet new xunit -n FizzBuzz.IntegrationTests`

cd FizzBuzz.UnitTests

`dotnet add reference ../../src/FizzBuzz/FizzBuzz.csproj`




To test:

`dotnet test`

To get code coverage (requires VS2017), run:

`dotnet test --collect:"Code Coverage"`

This outputs to ./TestResults - needs opening in VS2017