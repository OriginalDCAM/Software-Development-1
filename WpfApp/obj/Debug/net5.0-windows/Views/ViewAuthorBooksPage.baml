   M S B A M L   `   `   `  ����
  WpfApp&     WpfApp.Views.ViewAuthorBooksPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  Alle Items | Pagina��5      $	��720��6#   $
��1280��63   $
��Auto��6C   $
��Auto��6Q   .��5      � .+�5	   
   �  � RowDefinitions 5
      �� 5      $��8* �6    �� 5      $��8* �6    �� 5      $��* �6    �� 5      $��5* �6    .+�5      &   System.Windows.Controls.DataGrid  $��0��6      AutoGenerateColumns$ False��6$      EnableRowVirtualization$
 True��5         RowDetailsVisibilityMode$ VisibleWhenSelected=�5         CanUserAddRows$ False��5      "   VerticalScrollBarVisibility$
 Auto=�5      ��5      �� *EditableData+ �� SelectedItem 5      �� *SelectedAuthor+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Book Id��6@   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 SizeToHeader 5   )      
IsReadOnly$
 True��6>   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   )   �� *Id+5   >     5      $
	 Name��6B   $
 3* 6P    6)   �� *Name+6P     5      $	 Description��6I   $
 3* 6^    6)   �� *Description+6^   5        5      $��1��6   $ False��6$   $
 True��5      $ VisibleWhenSelected=�5!      $ False��5"       �� IsTextSearchEnabled$
 True��5#      ��5       �� *AuthorBooks+ 5%        5&      $	 Book Id��6@   $
 SizeToHeader 5'   )   $
 True��6>    5&   )   �� *Id+5'   >     5(      $
	 Name��6B   $
 3* 6P    6)   �� *Name+6P     5)      $	 Description��6I   $
 4* 6^    6)   �� *Description+6^     5*      $	 Genre��6C   $
 3* 6R   $
 True��6]    6)   �� *Genre+6]   5,      � 5-      $��2��6    � ColumnDefinitions 5.      �� 5/      $��* �6'   �� 50      $��* �6'   .+�52      �� $��0��6   $��
0,10, 0, 0q�6*   ���#00ADB5
�������$��Wijzigingen Bewaren��6�   ��6f   �� *SaveChangesCommand+6�   �� 53      $��1��6&   $��0, 10, 0, 0q�66   ���#D21312
�������$��Wijzigingen Weggooien��6�   ��6s   �� *RevertChangesCommand+6�   54      �� 55      $��3��6   $��Center=�6F   
��� � �$��30��6v   ��6&   �� *SuccessContent+6v   �� 56      $��3��6   $��Center=�6v   
���  ��$��30��6�   ��6&   �� *ErrorContent+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   57      58      59      