using HardkorowyKodsu.Services.Interfaces;

namespace HardkorowyKodsu
{
    public partial class MainView : Form
    {
        private readonly IDbApiService _dbApiService;

        public MainView(IDbApiService dbApiService)
        {
            InitializeComponent();
            ArgumentNullException.ThrowIfNull(dbApiService);
            _dbApiService = dbApiService;
            Task.Run(FillTable).Wait();
            Task.Run(FillViews).Wait();
        }
        private async Task FillTable()
        {
            TableList.Items.Clear();
            var tables = await _dbApiService.GetAllTablesAsync();
            TableList.Items.AddRange(tables.ToArray());
        }
        private async Task FillViews()
        {
            ViewList.Items.Clear();
            var views = await _dbApiService.GetAllViewsAsync();
            ViewList.Items.AddRange(views.ToArray());
        }

        private async void RealodClick(object sender, EventArgs e)
        {
            await FillTable();
            await FillViews();
            ColumnList.Items.Clear();
        }


        private async void List_Click(object sender, EventArgs e)
        {
            var tableName = ((ListBox)sender).SelectedItem?.ToString();
            if (tableName == null)
            {
                return;
            }
            var currentListBox = ((ListBox)sender);
            if (currentListBox.Name == nameof(ViewList))
            {
                TableList.SelectedItem = null;
            }
            else
            {
                ViewList.SelectedItem = null;
            }
            
            ColumnList.Items.Clear();
            var columns = await _dbApiService.GetColumnsAsync(tableName);
            ColumnList.Items.AddRange(columns.ToArray());
        }
    }
}
