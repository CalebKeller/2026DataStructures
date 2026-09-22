#:package Spectre.Console@0.53.*

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Spectre.Console;

// ═══════════════════════════════════════════════════════════════════════════════
// 🎨 GORGEOUS TUI SOLUTION GENERATOR
// ═══════════════════════════════════════════════════════════════════════════════

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Show stunning header
ShowHeader();

// Get project name with beautiful prompt
var projectName = args.Length > 0 ? args[0].Trim() : string.Empty;

if (string.IsNullOrWhiteSpace(projectName))
{
    projectName = AnsiConsole.Prompt(
        new TextPrompt<string>("[bold springgreen2]📁 Project Name[/]")
            .PromptStyle("cyan1")
            .ValidationErrorMessage("[red]Project name cannot be empty![/]")
            .Validate(name => !string.IsNullOrWhiteSpace(name)
                ? ValidationResult.Success()
                : ValidationResult.Error("[red]Please enter a valid project name[/]")));
}

if (string.IsNullOrWhiteSpace(projectName))
{
    AnsiConsole.MarkupLine("[bold red]❌ Project name is required.[/]");
    Environment.Exit(1);
}

var baseDir = Directory.GetCurrentDirectory();
var solutionDir = Path.Combine(baseDir, projectName);

if (Directory.Exists(solutionDir))
{
    AnsiConsole.MarkupLine($"[bold red]❌ A folder named [springgreen2]{projectName}[/] already exists in the current directory.[/]");
    AnsiConsole.MarkupLine("[yellow]Please choose a different project name or delete the existing folder.[/]");
    Environment.Exit(1);
}

// Show project preview
ShowProjectPreview(projectName);

// Confirm creation
if (!AnsiConsole.Confirm($"[bold cyan]Create solution [springgreen2]{projectName}[/] in current directory?[/]", true))
{
    AnsiConsole.MarkupLine("[yellow]🚫 Operation cancelled.[/]");
    Environment.Exit(0);
}

AnsiConsole.WriteLine();

// Create everything with gorgeous progress display
var steps = new[]
{
    new Step("Create solution structure"),
    new Step("Create Logic project (Class Library)"),
    new Step("Create WebUI project (Blazor)"),
    new Step("Create Tests project (xUnit)"),
    new Step("Create ConsoleUI project"),
    new Step("Wire up project references"),
    new Step("Add projects to solution"),
    new Step("Install NuGet packages"),
    new Step("Create .gitignore")
};

AnsiConsole.Live(BuildStepsTable(steps))
    //.AutoRefresh(true)
    .Start(ctx =>
    {
        void Refresh() => ctx.UpdateTarget(BuildStepsTable(steps));

        void RunStep(int index, Action action)
        {
            steps[index].Status = StepStatus.InProgress;
            Refresh();

            try
            {
                action();
                steps[index].Status = StepStatus.Complete;
            }
            catch
            {
                steps[index].Status = StepStatus.Failed;
                throw;
            }
            finally
            {
                Refresh();
            }
        }

        // Create Solution
        RunStep(0, () =>
        {
            Run("dotnet", $"new sln -o \"{projectName}\"", baseDir);
            Directory.SetCurrentDirectory(solutionDir);
        });

        // Create Projects in parallel
        var projectTasks = new[]
        {
            Task.Run(() => RunStep(1, () => Run("dotnet", $"new classlib -o \"{projectName}.Logic\"", solutionDir))),
            Task.Run(() => RunStep(2, () => Run("dotnet", $"new blazor -ai -e -o \"{projectName}.WebUI\"", solutionDir))),
            Task.Run(() => RunStep(3, () => Run("dotnet", $"new xunit -o \"{projectName}.Tests\"", solutionDir))),
            Task.Run(() => RunStep(4, () => Run("dotnet", $"new console -o \"{projectName}.ConsoleUI\"", solutionDir)))
        };

        Task.WaitAll(projectTasks);

        // Add References
        RunStep(5, () =>
        {
            var referenceTasks = new[]
            {
                Task.Run(() => Run("dotnet", $"add \"{projectName}.ConsoleUI\" reference \"{projectName}.Logic\"", solutionDir)),
                Task.Run(() => Run("dotnet", $"add \"{projectName}.WebUI\" reference \"{projectName}.Logic\"", solutionDir)),
                Task.Run(() => Run("dotnet", $"add \"{projectName}.Tests\" reference \"{projectName}.Logic\"", solutionDir))
            };

            Task.WaitAll(referenceTasks);
        });

        // Add to Solution
        RunStep(6, () =>
        {
            Run("dotnet", $"sln add \"{projectName}.ConsoleUI\" \"{projectName}.WebUI\" \"{projectName}.Tests\" \"{projectName}.Logic\"", solutionDir);
        });

        // Add Packages
        RunStep(7, () => Run("dotnet", $"add \"{projectName}.Tests\" package Shouldly", solutionDir));

        // Add .gitignore
        RunStep(8, () => Run("dotnet", "new gitignore", solutionDir));
    });

// Show success celebration
ShowSuccessBanner(projectName, solutionDir);

// Switch to the new solution directory
Directory.SetCurrentDirectory(solutionDir);
Run("code", ".", solutionDir, useShellExecute: true);

AnsiConsole.WriteLine();

// ═══════════════════════════════════════════════════════════════════════════════
// 🎨 BEAUTIFUL UI HELPERS
// ═══════════════════════════════════════════════════════════════════════════════

static void ShowHeader()
{
    AnsiConsole.Clear();
    AnsiConsole.WriteLine();

    // Stunning gradient figlet text
    AnsiConsole.Write(
        new FigletText("New")
            .Centered()
            .Color(Color.Cyan1));

    AnsiConsole.Write(
        new FigletText("Solution")
            .Centered()
            .Color(Color.SpringGreen2));

    AnsiConsole.WriteLine();

    // Subtitle with style
    var rule = new Rule("[bold grey]✨ Beautiful Solution Generator ✨[/]")
        .RuleStyle("cyan1")
        .Centered();
    AnsiConsole.Write(rule);

    AnsiConsole.WriteLine();
}

static Table BuildStepsTable(Step[] steps)
{
    var table = new Table()
        .Border(TableBorder.Rounded)
        .BorderStyle(Style.Parse("grey"))
        .AddColumn(new TableColumn("[bold cyan]Step[/]").LeftAligned())
        .AddColumn(new TableColumn("[bold cyan]Status[/]").Centered());

    foreach (var step in steps)
    {
        table.AddRow(step.Title, FormatStatus(step.Status));
    }

    return table;
}

static string FormatStatus(StepStatus status)
{
    return status switch
    {
        StepStatus.Pending => "[grey]⏳ Pending[/]",
        StepStatus.InProgress => "[yellow]▶ In progress[/]",
        StepStatus.Complete => "[springgreen2]✔ Complete[/]",
        StepStatus.Failed => "[red]✖ Failed[/]",
        _ => "[grey]-[/]"
    };
}

static void ShowProjectPreview(string projectName)
{
    AnsiConsole.WriteLine();

    // Create a beautiful tree showing project structure
    var tree = new Tree($"[bold springgreen2]📂 {projectName}/[/]")
        .Style("cyan1")
        .Guide(TreeGuide.BoldLine)
        ;

    var sln = tree.AddNode($"[grey]{projectName}.sln[/]");

    var logic = tree.AddNode($"[bold blue]📦 {projectName}.Logic/[/]");
    logic.AddNode("[grey]Class1.cs[/]");

    var webui = tree.AddNode($"[bold deeppink1]🌐 {projectName}.WebUI/[/]");
    webui.AddNode("[grey]Program.cs[/]");
    webui.AddNode("[grey]Components/[/]");

    var tests = tree.AddNode($"[bold orange1]🧪 {projectName}.Tests/[/]");
    tests.AddNode("[grey]UnitTest1.cs[/]");

    var console = tree.AddNode($"[bold green]💻 {projectName}.ConsoleUI/[/]");
    console.AddNode("[grey]Program.cs[/]");

    tree.AddNode("[grey].gitignore[/]");
    
    // Wrap tree in a panel
    var structurePanel = new Panel(tree)
        .Header("[bold white] 📋 Project Structure [/]" )
        .HeaderAlignment(Justify.Center)
        .Border(BoxBorder.Rounded)
        .BorderStyle(Style.Parse("cyan1"))
        .Padding(1, 1);
    structurePanel.Width = 40;

    // Show references table
    var refTable = new Table()
        .Border(TableBorder.Rounded)
        .BorderStyle(Style.Parse("grey"))
        .AddColumn(new TableColumn("[bold cyan]Project[/]").LeftAligned())
        .AddColumn(new TableColumn("[bold cyan]References[/]").Centered())
        .AddColumn(new TableColumn("[bold cyan]Packages[/]").Centered());

    refTable.AddRow(
        $"[blue]{projectName}.Logic[/]",
        "[grey]-[/]",
        "[grey]-[/]");
    refTable.AddRow(
        $"[deeppink1]{projectName}.WebUI[/]",
        $"[blue]→ {projectName}.Logic[/]",
        "[grey]-[/]");
    refTable.AddRow(
        $"[orange1]{projectName}.Tests[/]",
        $"[blue]→ {projectName}.Logic[/]",
        "[mediumpurple1]Shouldly[/]");
    refTable.AddRow(
        $"[green]{projectName}.ConsoleUI[/]",
        $"[blue]→ {projectName}.Logic[/]",
        "[grey]-[/]");

    var dependenciesPanel = new Panel(refTable)
        .Header("[bold white] 🔗 Dependencies [/]" )
        .HeaderAlignment(Justify.Center)
        .Border(BoxBorder.Rounded)
        .BorderStyle(Style.Parse("mediumpurple1"))
        .Padding(1, 0);

    var availableWidth = Math.Max(AnsiConsole.Profile.Width, Console.WindowWidth);
    var sideBySideMinWidth = 50;

    if (availableWidth >= sideBySideMinWidth)
    {
        var columns = new Columns(structurePanel, dependenciesPanel)
        {
            Expand = false,
            Padding = new Padding(1, 0, 1, 0)
        };

        AnsiConsole.Write(columns);
        AnsiConsole.WriteLine();
    }
    else
    {
        AnsiConsole.Write(structurePanel);
        AnsiConsole.WriteLine();
        AnsiConsole.Write(dependenciesPanel);
        AnsiConsole.WriteLine();
    }
}

static void ShowSuccessBanner(string projectName, string solutionDir)
{
    AnsiConsole.WriteLine();

    // Success animation
    AnsiConsole.Write(
        new FigletText("SUCCESS!")
            .Centered()
            .Color(Color.SpringGreen2));

    AnsiConsole.WriteLine();

    // Stats panel
    var grid = new Grid()
        .AddColumn()
        .AddColumn();

    grid.AddRow(
        new Markup("[bold grey]Solution:[/]"),
        new Markup($"[bold springgreen2]{projectName}.sln[/]"));
    grid.AddRow(
        new Markup("[bold grey]Location:[/]"),
        new Markup($"[cyan1]{solutionDir}[/]"));
    grid.AddRow(
        new Markup("[bold grey]Projects:[/]"),
        new Markup("[bold white]4[/] [grey](Logic, WebUI, Tests, ConsoleUI)[/]"));
    grid.AddRow(
        new Markup("[bold grey]Template:[/]"),
        new Markup("[deeppink1]Blazor[/] [grey]+[/] [blue]ClassLib[/] [grey]+[/] [orange1]xUnit[/] [grey]+[/] [green]Console[/]"));

    var successPanel = new Panel(grid)
        .Header("[bold white] ✅ Solution Created Successfully! [/]")
        .HeaderAlignment(Justify.Center)
        .Border(BoxBorder.Heavy)
        .BorderStyle(Style.Parse("springgreen2"))
        .Padding(2, 1);

    AnsiConsole.Write(successPanel);
    AnsiConsole.WriteLine();
}

static void Run(string fileName, string arguments, string workingDirectory, bool useShellExecute = false)
{
    var psi = new ProcessStartInfo
    {
        FileName = fileName,
        Arguments = arguments,
        WorkingDirectory = workingDirectory,
        UseShellExecute = useShellExecute,
        RedirectStandardOutput = !useShellExecute,
        RedirectStandardError = !useShellExecute,
        CreateNoWindow = !useShellExecute
    };

    using var process = new Process { StartInfo = psi };

    if (!process.Start())
    {
        throw new InvalidOperationException($"Failed to start {fileName} {arguments}");
    }

    if (!useShellExecute)
    {
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();

        if (process.ExitCode != 0)
        {
            throw new InvalidOperationException($"Command failed ({process.ExitCode}): {fileName} {arguments}");
        }
    }
}


enum StepStatus
{
    Pending,
    InProgress,
    Complete,
    Failed
}

sealed class Step
{
    public Step(string title)
    {
        Title = title;
        Status = StepStatus.Pending;
    }

    public string Title { get; }
    public StepStatus Status { get; set; }
}