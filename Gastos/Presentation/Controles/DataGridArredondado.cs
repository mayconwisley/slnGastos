using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gastos.Presentation.Controles;

public sealed class DataGridArredondado : DataGrid
{
    private const double RaioDosCantos = 13;

    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        base.OnRenderSizeChanged(sizeInfo);

        Clip = new RectangleGeometry(
            new Rect(0, 0, ActualWidth, ActualHeight),
            RaioDosCantos,
            RaioDosCantos);
    }
}
