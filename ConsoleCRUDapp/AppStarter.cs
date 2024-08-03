using System;
using System.Windows.Forms;
using DataAccess;
using MasterClass;

namespace ConsoleCRUDapp
{
    /// <summary>
    /// Entrypoint of Project
    /// </summary>
    public class AppStarter
    {
        /// <summary>
        /// Entrypoint method || Driver code of Program
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
			try
			{
                // Set up event handler for Ctrl+C
                Console.CancelKeyPress += new ConsoleCancelEventHandler(OnExit);
                // Set up global exception handler
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);

                Utilities.ConsoleUtility.SetConsoleFont();

                Views.MenuView.RootMenuDisplay();

                Console.ReadLine();
            }
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), GlobalModel.AppName_);
			}
            finally
            {
                Cleanup();
            }
        }

        /// <summary>
        /// To handle exit event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <exception cref="Exception"></exception>
        private static void OnExit(object sender, ConsoleCancelEventArgs args)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\tExiting gracefully...\n\n");
                args.Cancel = true; // Cancel the termination to perform cleanup

                // Perform any necessary cleanup
                Cleanup();

                // Exit the application
                Environment.Exit(0);
            }
            catch(Exception ex)
            {
                throw new Exception($"\nConsoleCRUDapp.AppStarter.OnExit()::{ex.Message}");
            }
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            try
            {
                Exception ex = (Exception)args.ExceptionObject;
                Console.WriteLine($"Unhandled exception: {ex.Message}");

                // Perform any necessary cleanup
                Cleanup();

                // Exit the application
                Environment.Exit(1);
            }
            catch(Exception ex)
            {
                throw new Exception($"\nConsoleCRUDapp.AppStarter.UnhandledExceptionHandler()::{ex.Message}");
            }
        }

        private static void Cleanup()
        {
            try
            {
                // Console.WriteLine("Cleaning up resources...");
            }
            catch(Exception ex)
            {
                throw new Exception($"\nConsoleCRUDapp.AppStarter.Cleanup()::{ex.Message}");
            }
        }
    }
}
