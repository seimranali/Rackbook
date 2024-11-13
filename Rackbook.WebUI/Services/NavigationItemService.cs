using Rackbook.Domain.Entities;
namespace Rackbook.WebUI.Services
{

    public class NavigationItemService
    {

        private NavigationItem[] allNavigationItems;

        public NavigationItem[] NavigationItems
        {
            get
            {
                return allNavigationItems;
            }
            set
            {
                allNavigationItems = value;
            }
        }

        public IEnumerable<NavigationItem> Filter(string term)
        {
            if (string.IsNullOrEmpty(term))
                return allNavigationItems;

            bool contains(string value) => value != null && value.Contains(term, StringComparison.OrdinalIgnoreCase);

            bool filter(NavigationItem navigationItem) => contains(navigationItem.NavigationItemName);

            bool deepFilter(NavigationItem navigationItem) => filter(navigationItem) || navigationItem.Children?.Any(filter) == true;

            return NavigationItems.Where(category => category.Children?.Any(deepFilter) == true || filter(category))
                           .Select(category => new NavigationItem
                           {
                               NavigationItemName = category.NavigationItemName,
                               NavigationItemPath = category.NavigationItemPath,
                               NavigationItemIcon = category.NavigationItemIcon,
                               Children = category.Children?.Where(deepFilter).Select(navigationItem => new NavigationItem
                               {
                                   NavigationItemName = navigationItem.NavigationItemName,
                                   NavigationItemPath = navigationItem.NavigationItemPath,
                                   NavigationItemIcon = navigationItem.NavigationItemIcon,
                                   Children = navigationItem.Children
                               }
                               ).ToArray()
                           }).ToList();
        }

        public NavigationItem FindCurrent(Uri uri)
        {
            IEnumerable<NavigationItem> Flatten(IEnumerable<NavigationItem> e)
            {
                return e.SelectMany(c => c.Children != null ? Flatten(c.Children) : new[] { c });
            }

            return Flatten(NavigationItems)
                        .FirstOrDefault(example => example.NavigationItemPath == uri.AbsolutePath || $"/{example.NavigationItemPath}" == uri.AbsolutePath);
        }

        public string TitleFor(NavigationItem navigationItem)
        {
            if (navigationItem != null && navigationItem.NavigationItemName != "Overview")
            {
                return navigationItem.NavigationItemTitle ?? $"Blazor {navigationItem.NavigationItemName} Component | Free UI Components by Radzen";
            }

            return "Free Blazor Components | 70+ UI controls by Radzen";
        }

        public string DescriptionFor(NavigationItem navigationItem)
        {
            return navigationItem?.NavigationItemDescription ?? "The Radzen Blazor component library provides more than 70 UI controls for building rich ASP.NET Core web applications.";
        }
    }

}
