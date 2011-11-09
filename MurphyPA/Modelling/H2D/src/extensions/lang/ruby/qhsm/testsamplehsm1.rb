require 'qhsm.rb'

# generated by PythonGenerator version 0.1

class TestSample1 < QHsm

    def initialiseStateMachine()
        initialiseState(method(:s_StateX))
    end


    def s_StateX(ev)
        if ev.qsignal == QSignals::Entry 
            enterStateX()
        elsif ev.qsignal == QSignals::Exit
            exitStateX()
        elsif ev.qsignal == QSignals::Init:
            initialiseState(method(:s_State0))
        else
            return @_topState
        end
        return nil
    end
    

    def s_State0(ev)
        if ev.qsignal == "Bye"
            ;
            transitionTo(method(:s_State1))
        elsif ev.qsignal == "Hello"
            if Ok(ev):
                sayHello3()
                transitionTo(method(:s_State0))
            else
                sayHello1()
                transitionTo(method(:s_State1))
            end
        elsif ev.qsignal == QSignals::Entry
            enterState0()
        elsif ev.qsignal == QSignals::Exit
            exitState0()
        else
            return method(:s_StateX)
        end
        return nil
    end
    

    def s_State1(ev)
        if ev.qsignal == "Hello"
            sayHello2()
            transitionTo(method(:s_State0))
        elsif ev.qsignal == QSignals::Entry
            enterState1()
        elsif ev.qsignal == QSignals::Exit
            exitState1()
        else
            return @_topState
        end
        return nil
    end

    #end of TestSample1
end

