   M S B A M L   `   `   `  ����E  AСursovaya, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Сursovaya.FormsСursovaya.Forms  5   	   #    Сursovaya.Forms.ProviderForm   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   0localclr-namespace:Сursovaya.Forms     5   	     � Title$  Поставщики��5   	   $	��450��6   $	��450��6)    � 
ResizeMode$ NoResize=�65   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��120 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5      �� -   5        $��30��5   *   $	��100��66   $
��Left=�6B   $��Bottom=�6]   $��0,0,0,10q�6x   .��6�   Добавить6�   �� 5      -   5        $��30��5   -   $	��100��69   $
��Left=�6E   $��Bottom=�6`   $��	10,0,0,10q�6{   .��6�   Обновить6�   �� 5      -   5        $��30��5   -   $	��100��69   $
��Left=�6E   $��Bottom=�6`   $��	10,0,0,10q�6{   .��6�   Удалить6�   �� 5      -   5        $��
idProvider��5   �   $��30��6   $	��100��6"   $
��Left=�6.   $��Bottom=�6I   $��	10,0,0,10q�6e   $��ID Поставщика��6x   $��Center=�6�   $��Center=�6�   5      �� 5   
   $��Center=�6   $	��Top=�62   .+�5      �� -   5        $
��name��5   k   $��30��6   $	��440��6"   $
��Left=�6.   $��0,5,0,10q�6I   $��Название��6[   $��Center=�6w   $��Center=�6�   �� 5      -   5        $��phone��5   q   $��30��6   $	��440��6"   $
��Left=�6.   $��0,0,0,10q�6I   $!��Номер телефона��6[   $��Center=�6~   $��Center=�6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
MyDataGrid��5       $��1��6      AutoGenerateColumns$ False��64      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID Поставщика��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6`   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6<   �� 
 �� Path$
 
IdProvider�6`     5      $ Имя��6%   $	 120 6P   	 62   �� $

 Name�6P     5      $! Номер телефона��6%   $	 250 6b   	 6=   �� $
 PhoneNumber�6b   5      5      5       