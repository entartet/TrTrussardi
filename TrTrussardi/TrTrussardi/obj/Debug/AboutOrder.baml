   M S B A M L   `   `   `  ����F  BTrTrussardi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TrTrussardiTrTrussardi  5   	       TrTrussardi.AboutOrder   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TrTrussardi     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��350��5	   	   $	��300��6     � WindowStartupLocation$  CenterScreen=�6"   .��5
      �� -   5        $��ss��5
      .+�5   
   �� -   5        $��
OrdersList��5       � IsSharedSizeScope . ��5      �� 5      .R�5      ��  ��Name$ Border��6    �� Padding$ 8q�61   $��0 0 0 1q�6?      MaterialDesignDivider#���   6Z   ._�5      �  � ColumnDefinitions 5      �� 5   "    z� SharedSizeGroup$ Checkerz��64   �� 5   "   �� 5   "   $��50 �63   .+�5      d� $��Center=�6.    ) %MaterialDesignActionLightToggleButton#��[ 6p    d� 	IsChecked 6L   �� *
IsSelected+6p   �� 5      $��8 0 0 0q�6+   $��1��6?   .+�5   "   �� $
��Bold"�6,   ��6A   �� *Dishes.Name+�� 5   "   ��6,   �� *
Dishes.Val+5      5      5       �� Triggers 5      �� 5       �� Value$
 True��6L   	 �� Binding	 6)   �� *
IsSelected+.a�5      �� 
 �� 
TargetName$
 Border��6,     MaterialDesignSelection �� Value# �  6Z    �� Property � ��5      5!      5#      �� 5$   
   -   5        $��
40 10 40 0q�5$   &   .��6:   Заказ выполнен6J   5%      5&      