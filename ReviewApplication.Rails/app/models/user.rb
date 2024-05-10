class User < ApplicationRecord
    has_one :bank_account
    has_secure_password
end
