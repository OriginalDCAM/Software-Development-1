   M S B A M L   `   `   `  ����
  WpfApp#    WpfApp.Views.CreateAuthorPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  Auteur Aanmaken | Pagina��5      $
��Auto��6(   $
��Auto��65   $	��450��6C   $	��800��6S    � 	Resources 5      ��%    5	      .��5
      �  � ColumnDefinitions 5   
   �� 5      $��4* �6   �� 5      $��3* �6   �� 5      $��4* �6    � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $
��Auto �6   �� 5      $��1* �6   �� 5      $��3* �6   .+�5   
   � .+�5      �� -   5        $��8q�5      $��20��6    $
��Auto��6,   ���#00ADB5
�������$��14(�6   .��6�   Ga Terug naar alle items6�   5      �� 5   
   $��1��6   $��1��6"   .+�5      �� $��24(�6   Auteur Aanmaken:68   �� 5      $��Voer een naam in:��6   $��Arial)�60   $��18(�6C    �� Target 5      ��  �� ElementName$ BookNameTextBox���� 5      -   5        $��BookNameTextBox��5      $��Arial)�6-   $��24(�6@   $��25��5   ]   ��6   �� *NameProperty+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors$
 True��6]   �� 5      $��Voer een beschrijving in:��6   $��Arial)�68   $��18(�6K    5       �� $ BookDescTextBox���� 5!      -   5        $��BookDescTextBox��5"       �� TextWrapping$
 Wrap=�5#      	 �� AcceptsReturn$
	 True��5$      "
 �� VerticalScrollBarVisibility$
 Visible=�5%      $��Arial)�5&      $��24(�5'      $	��100��5)      ��5(      �� *DescriptionProperty+$ TwoWay=�$
 True��5)      �� 5*      $��5��6   $y�Hidden=�6#   �� 5+      ���#00ADB5
�������$��14(�6e   $��Maak aan��5,      ��5+      �� *CreateAuthorCommand+5,      5-      �� 5.      $��2��6   $��1��6%   $��Center=�6�   
���  ��$��30��6�   ��65   �� *ErrorContent+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5/      $��2��6   $��1��6%   $��Center=�6U   
��� � �$��30��6�   ��65   �� *SuccessContent+6�   50      51      