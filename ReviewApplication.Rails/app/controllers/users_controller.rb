class UsersController < ApplicationController
  
  
  
  def new
    @user = User.new
  end

  def create
    @user = User.new(user_params)
    @bank_account = BankAccount.new(user: @user)

    if @user.save && @bank_account.save
      session[:user_id] = @user.id
      redirect_to bank_account_path(@bank_account), notice: 'User was successfully created.'
    else
      render :new
    end
  end

  private

  def user_params
    params.require(:user).permit(:email, :password, :password_confirmation)
  end
end