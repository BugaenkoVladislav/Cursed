   M S B A M L   `   `   `  ����E  AСursovaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Сursovaya.ReportFormsСursovaya.ReportForms  5   	   +    %Сursovaya.ReportForms.ProductBuyForm   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   6local$clr-namespace:Сursovaya.ReportForms     5   	     � Title$#  Покупки товаров��5   	   $	��600��6!   $	��500��6.    � 
ResizeMode$ NoResize=�6:   .��5	      �  � RowDefinitions 5
   
   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5      �� -   5        $��0��5      $��30��69   $	��250��6E   $
��Left=�6Q   .��6l   Фильтр6t   �� 5      -   5        $��idBuy��5   �   $��30��6   $��70��6"   $
��Left=�6-   $��Bottom=�6H   $��	10,0,0,10q�6d   $��Покупка��6w   $��Center=�6�   $��Center=�6�   �� 5      -   5        $��	idProduct��5   �   $��30��6   $��75��6"   $
��Left=�6-   $��Bottom=�6H   $��	10,0,0,10q�6d   $��
Товар��6w   $��Center=�6�   $��Center=�6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
MyDataGrid��5       $��1��6      AutoGenerateColumns$ False��64      RowBackground
 �����   AlternatingRowBackground
 �����   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Номер покупки��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 100 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   ��  �� Path$ IdBuy�6[     5      $	 
Товар��6%   $
 80 6W    64   �� $ 	IdProduct�6W     5      $	 Количество��6%   $
 80 6X    69   �� $ Count�6X     5      $	 Цена(шт)��6%   $
 80 6V    67   �� $ Price�6V     5      $	 
Сумма��6%   $	
 110 6Q    64   �� $	 Sum�6Q   5      5       5!      