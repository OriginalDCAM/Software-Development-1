   M S B A M L   `   `   `  ����
  WpfApp!    WpfApp.Views.CreateBookPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  Boek Aanmaken | Pagina��5      $
��Auto��6&   $	��720��64   $
��Auto��6D   $
��1280��6Q    � 	Resources 5      ��%    5	      .��5
      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��3* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $
��Auto �6   �� 5      $��1* �6   �� 5      $��3* �6   .+�5   
   � .+�5      �� -   5        $��20��5      $��8q�6!   $
��Auto��6,   ���#00ADB5
�������$��14(�6   .��6�   Ga Terug naar alle items6�   5      �� 5   
   $��1��6   $��1��6"   .+�5      �� $��24(�6   Boek Aanmaken:66   �� 5      $��Voer een naam in:��6   $��Arial)�60   $��18(�6C    �� Target 5      ��  �� ElementName$ BookNameTextBox���� 5      -   5        $��BookNameTextBox��5      $��Arial)�6-   $��24(�6@   $��25��6l   ��6N   �� *NameProperty+6l   �� 5      $��Voer een beschrijving in:��6   $��Arial)�68   $��18(�6K    5      �� $ BookDescTextBox���� 5       -   5        $��BookDescTextBox��5       $��Arial)�6-   $��24(�6@   $��25��5!      ��5    N   �� *DescriptionProperty+5!      � 5"      .+�5#      �� $#��Kies uit een van deze genres:��6   $��Arial)�6@   $��18(�6S    5$      �� $ GenreComboBox���� 5%      $��10��6   
������ 6'   �� 5&      -   5        $��GenreComboBox��5&      $��Arial)�60   $��16(�6C   $
��Auto��6Q   $��20��6^   ��5'      ��  �� Path$ Genres� �� SelectedItem 6?   �� $ SelectedGenre���5(      �� 5)      .R�5*      �� ��6(   �� 5+      5-      5.      �� 5/      .+�50      �� $E��?Zoek voor een auteur en selecteer een uit deze lijst hieronder:��6   $��Arial)�6b   $��18(�51      �� 52      $
��Auto��6   $��25��53      ��52   '   �� *SearchQuery+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�53      �� 54      $��5��6   $y�Hidden=�6'   �� 55      $
��Auto��6   $	��100��6'   $��16(�64   $��Arial)�6B   
 �� DisplayMemberPath$

 Name��57       �� SelectedValuePath$ Id��58      ��56      �� *	Authors+$ TwoWay=� �� SelectedValue 59      �� *Id+$ TwoWay=�5:      �� 5;      ���#00ADB5
�������$��14(�6c   $��Maak aan��5<      ��5;      �� *CreateBookCommand+5<      �� 5=      $��Center=�5>      $��30��5@      ��5=      �� *MessageProperty+$ TwoWay=�$	 PropertyChanged=���5?      �� *MessagePropertyColor+$ TwoWay=�$	 PropertyChanged=�5@      5A      �� 5B      $��2��6   $��1��6%   $��Center=�6�   
���  ��$��30��6�   ��65   �� *ErrorContent+$ TwoWay=�$	 PropertyChanged=�6�   �� 5C      $��2��6   $��1��6%   $��Center=�6U   
��� � �$��30��6�   ��65   �� *SuccessContent+6�   5D      5E      