class SessionsController < ApplicationController
  

  def new
  end

  def create
    user = User.find_by(email: params[:email])
    if user && user.authenticate(params[:password]) && user.bank_account.present?
      session[:user_id] = user.id
      redirect_to bank_account_path(user.bank_account,  username: user.email)
    else
      flash.now[:alert] = 'Invalid email/password combination'
      render :new
    end
  end

  def destroy
    session[:user_id] = nil
    redirect_to root_url, notice: 'Logged out!'
  end
end