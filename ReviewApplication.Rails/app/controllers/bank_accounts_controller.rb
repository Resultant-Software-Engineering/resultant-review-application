class BankAccountsController < ApplicationController
  before_action :set_user_and_bank_account

  def show  
    @transactions = @bank_account.transactions
  end

  private

  def set_user_and_bank_account
    @user = User.find_by(email: params[:username])
    if @user
      @bank_account = @user.bank_account
    else
      redirect_to root_url, alert: 'User not found'
    end
  end
end